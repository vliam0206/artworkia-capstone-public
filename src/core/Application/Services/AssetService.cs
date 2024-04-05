using Application.Commons;
using Application.Filters;
using Application.Models;
using Application.Services.Abstractions;
using Application.Services.Firebase;
using AutoMapper;
using Domain.Entities.Commons;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;
public class AssetService : IAssetService
{
    private static readonly string PARENT_FOLDER = "Artwork";
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IFirebaseService _firebaseService;
    private readonly IClaimService _claimService;

    public AssetService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IFirebaseService firebaseService,
        IClaimService claimService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _firebaseService = firebaseService;
        _claimService = claimService;
    }

    public async Task<IPagedList<AssetVM>> GetAllAssetsAsync(AssetCriteria criteria)
    {
        Guid? accountId = _claimService.GetCurrentUserId;

        var listAsset = await _unitOfWork.AssetRepository.GetAllAssetsAsync(
            null, criteria.MinPrice, criteria.MaxPrice, criteria.Keyword, criteria.SortColumn, criteria.SortOrder, criteria.PageNumber, criteria.PageSize);
        var listAssetVM = _mapper.Map<PagedList<AssetVM>>(listAsset);

        // check if user is logged in
        if (accountId != null)
        {
            foreach (var asset in listAssetVM.Items)
            {
                var isBought = await _unitOfWork.TransactionHistoryRepository.GetAssetTransactionAsync(accountId.Value, asset.Id);
                asset.IsBought = isBought != null;
            }
        }
        return listAssetVM;
    }

    public async Task<IPagedList<AssetVM>> GetAssetsOfAccountAsync(Guid accountId, AssetCriteria criteria)
    {
        var listAsset = await _unitOfWork.AssetRepository.GetAllAssetsAsync(
            accountId, criteria.MinPrice, criteria.MaxPrice, criteria.Keyword, criteria.SortColumn, criteria.SortOrder, criteria.PageNumber, criteria.PageSize);
        var listAssetVM = _mapper.Map<PagedList<AssetVM>>(listAsset);
        return listAssetVM;
    }

    public async Task<AssetVM?> GetAssetByIdAsync(Guid assetId)
    {
        Guid? accountId = _claimService.GetCurrentUserId;

        var asset = await _unitOfWork.AssetRepository.GetByIdAsync(assetId);
        if (asset == null)
            throw new NullReferenceException("Không tìm thấy tài nguyên.");
        if (asset.DeletedOn != null)
            throw new Exception("Tài nguyên đã bị xóa.");
        var assetVM = _mapper.Map<AssetVM>(asset);

        // check if user is logged in
        if (accountId != null)
        {
            var isBought = await _unitOfWork.TransactionHistoryRepository.GetAssetTransactionAsync(accountId.Value, assetId);
            assetVM.IsBought = isBought != null;
        }

        // get metadata of asset
        try
        {
            var fileMetaData = await _firebaseService.GetMetadataFileFromFirebaseStorage(assetVM.AssetName, $"{PARENT_FOLDER}/Asset");
            if (fileMetaData != null)
            {
                assetVM.FileMetaData = fileMetaData;
            }
        }
        catch (Exception ex)
        {
            //throw new Exception("Cannot get metadata of asset! Maybe file was deleted on cloud storage: " + ex);
        }
        return assetVM;
    }

    public async Task<string?> GetDownloadUriAssetAsync(Guid assetId)
    {
        var asset = await _unitOfWork.AssetRepository.GetAssetAndItsCreatorAsync(assetId);
        if (asset == null)
            throw new NullReferenceException("Không tìm thấy tài nguyên.");

        // kiem tra xem user da mua asset chua
        var accountId = _claimService.GetCurrentUserId ?? default;
        var assetTransaction = await _unitOfWork.TransactionHistoryRepository.GetSingleByConditionAsync(
            x => x.AssetId == assetId && x.CreatedBy == accountId);
        if (assetTransaction != null)
            return asset.Location;

        if (asset.Artwork.CreatedBy == accountId)
            return asset.Location;

        if (asset.DeletedOn != null)
            throw new Exception("Tài nguyên đã bị xóa.");

        if (asset.Price > 0)
            throw new Exception("Bạn chưa mua tài nguyên này.");

        return asset.Location;
    }

    public async Task<string?> GetDownloadUriAssetForModerationAsync(Guid assetId)
    {
        var asset = await _unitOfWork.AssetRepository.GetAssetAndItsCreatorAsync(assetId);
        if (asset == null)
            throw new NullReferenceException("Không tìm thấy tài nguyên.");
        return asset.Location;
    }

    public async Task<string?> GetDownloadUriAssetAlternativeAsync(Guid assetId)
    {
        var asset = await _unitOfWork.AssetRepository.GetAssetAndItsCreatorAsync(assetId);
        if (asset == null)
            throw new NullReferenceException("Không tìm thấy tài nguyên.");

        var link = await _firebaseService.DownloadFileFromFirebaseStorage(asset.AssetName, $"{PARENT_FOLDER}/Asset");

        // kiem tra xem user da mua asset chua
        var accountId = _claimService.GetCurrentUserId ?? default;
        var assetTransaction = await _unitOfWork.TransactionHistoryRepository.GetSingleByConditionAsync(
            x => x.AssetId == assetId && x.CreatedBy == accountId);
        if (assetTransaction != null)
            return link;

        if (asset.Artwork.CreatedBy == accountId)
            return link;

        if (asset.DeletedOn != null)
            throw new Exception("Tài nguyên đã bị xóa.");

        if (asset.Price > 0)
            throw new Exception("Bạn chưa mua tài nguyên này.");

        return link;
    }

    // lay so thu tu lon nhat cua asset trong artwork
    private async Task<int> GetLatestOrderOfAssetInArtwork(Guid artworkId)
    {
        var allAssetsOfArtwork = await _unitOfWork.AssetRepository.GetListByConditionAsync(x => x.ArtworkId == artworkId);
        return allAssetsOfArtwork.Count;
    }

    public async Task<AssetVM> AddAssetAsync(AssetModel assetModel)
    {
        // kiem tra artwork co ton tai khong
        var artwork = await _unitOfWork.ArtworkRepository.GetByIdAsync(assetModel.ArtworkId);
        if (artwork == null)
            throw new NullReferenceException("Không tìm thấy tác phẩm.");
        if (artwork.DeletedOn != null)
            throw new Exception("Tác phẩm đã bị xóa.");

        // lay stt cua hinh anh, dat ten lai hinh anh
        int latestOrder = await GetLatestOrderOfAssetInArtwork(assetModel.ArtworkId);
        string newAssetName = assetModel.ArtworkId + "_a" + latestOrder;
        string folderName = $"{PARENT_FOLDER}/Asset";
        string imageExtension = Path.GetExtension(assetModel.File.FileName); // lay duoi file (.zip, .rar, ...)


        // upload asset len firebase, lay url
        var url = await _firebaseService.UploadFileToFirebaseStorage(assetModel.File, newAssetName, folderName);
        if (url == null)
            throw new Exception("Không thể tải tài nguyên lên Firebase.");

        // map assetModel sang asset
        Asset newAsset = _mapper.Map<Asset>(assetModel);
        newAsset.Location = url;
        newAsset.AssetName = newAssetName + imageExtension;
        await _unitOfWork.AssetRepository.AddAsync(newAsset);
        await _unitOfWork.SaveChangesAsync();

        var assetVM = _mapper.Map<AssetVM>(newAsset);
        return assetVM;
    }

    public async Task AddRangeAssetAsync(MultiAssetModel multiAssetModel, bool isSaveChanges = true)
    {
        #region validate
        // kiem tra artwork co ton tai khong
        bool IsArtworkExisted = await _unitOfWork.ArtworkRepository.IsExistedAsync(multiAssetModel.ArtworkId);
        if (!IsArtworkExisted)
            throw new NullReferenceException("Không tìm thấy tác phẩm.");
        var allAssetsOfArtwork = await _unitOfWork.AssetRepository.GetListByConditionAsync(x => x.ArtworkId == multiAssetModel.ArtworkId);
        if (allAssetsOfArtwork.Count > 0)
            throw new Exception("Tác phẩm đã có tài nguyên.");
        #endregion

        #region upload asset (optimize)
        //var uploadAssetsTask = new List<Task>();
        //foreach (var singleAsset in multiAssetModel.Assets.Select((file, index) => (file, index)))
        //{
        //    Guid artworkId = multiAssetModel.ArtworkId;
        //    string newAssetName = artworkId + "_a" + singleAsset.index;
        //    string folderName = $"{PARENT_FOLDER}/Asset";
        //    string imageExtension = Path.GetExtension(singleAsset.file.File.FileName); // lay duoi file (.zip, .rar, ...)

        //    // upload asset len firebase, lay url
        //    uploadAssetsTask.Add(Task.Run(async () =>
        //    {
        //        var url = await _firebaseService.UploadFileToFirebaseStorage(singleAsset.file.File, newAssetName, folderName);
        //        if (url == null)
        //            throw new Exception("Cannot upload asset to firebase!");

        //        Asset newAsset = new()
        //        {
        //            ArtworkId = artworkId,
        //            Location = url,
        //            AssetName = newAssetName + imageExtension,
        //            AssetTitle = singleAsset.file.AssetTitle,
        //            Description = singleAsset.file.Description,
        //            Price = singleAsset.file.Price,
        //        };
        //        await _unitOfWork.AssetRepository.AddAsync(newAsset);
        //    }));
        //}
        //await Task.WhenAll(uploadAssetsTask);
        #endregion

        #region upload asset (legacy)
        int index = 0;
        foreach (var singleAsset in multiAssetModel.Assets)
        {
            string newAssetName = multiAssetModel.ArtworkId + "_a" + index;
            string folderName = $"{PARENT_FOLDER}/Asset";
            string imageExtension = Path.GetExtension(singleAsset.File.FileName); // lay duoi file (.zip, .rar, ...)

            // upload asset len firebase, lay url
            var url = await _firebaseService.UploadFileToFirebaseStorage(singleAsset.File, newAssetName, folderName);
            if (url == null)
                throw new Exception("Không thể tải tài nguyên lên Firebase.!");

            Asset newAsset = new Asset()
            {
                ArtworkId = multiAssetModel.ArtworkId,
                AssetTitle = singleAsset.AssetTitle,
                Description = singleAsset.Description,
                Price = singleAsset.Price,
                Location = url,
                AssetName = newAssetName + imageExtension,
            };
            await _unitOfWork.AssetRepository.AddAsync(newAsset);
            index++;
        }
        #endregion

        if (isSaveChanges)
            await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAssetAsync(Guid assetId)
    {
        var result = await _unitOfWork.AssetRepository.GetByIdAsync(assetId);
        if (result == null)
            throw new Exception("Không tìm thấy tài nguyên.");
        _unitOfWork.AssetRepository.SoftDelete(result);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAssetAsync(Guid assetId, AssetEM assetEM)
    {
        var oldAsset = await _unitOfWork.AssetRepository.GetByIdAsync(assetId);
        if (oldAsset == null)
            throw new NullReferenceException("Không tìm thấy tài nguyên.");
        oldAsset.AssetTitle = assetEM.AssetTitle;
        oldAsset.Description = assetEM.Description;
        oldAsset.Price = assetEM.Price;

        _unitOfWork.AssetRepository.Update(oldAsset);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<AssetVM>> GetAllAssetsOfArtworkAsync(Guid artworkId)
    {
        var listAssetOfArtwork = await _unitOfWork.AssetRepository.GetListByConditionAsync(x => x.ArtworkId == artworkId);
        if (listAssetOfArtwork == null)
            throw new NullReferenceException("Tác phẩm này không có tài nguyên nào.");
        var listAssetVMOfArtwork = _mapper.Map<List<AssetVM>>(listAssetOfArtwork);
        return listAssetVMOfArtwork;
    }

    public async Task<IPagedList<AssetVM>> GetAssetsBoughtOfAccountAsync(Guid accountId, PagedCriteria criteria)
    {
        var transactionAssets = await _unitOfWork.TransactionHistoryRepository.GetAssetsBoughtOfAccountAsync(accountId, criteria.PageNumber, criteria.PageSize);
        List<AssetVM> listAssetVM = new();
        foreach (var transaction in transactionAssets.Items)
        {
            var assetVM = _mapper.Map<AssetVM>(transaction.Asset);
            assetVM.IsBought = true;
            listAssetVM.Add(assetVM);
        }
        PagedList<AssetVM> pagedList = new(listAssetVM, transactionAssets.TotalCount, transactionAssets.CurrentPage, transactionAssets.PageSize);
        return pagedList;
    }
}