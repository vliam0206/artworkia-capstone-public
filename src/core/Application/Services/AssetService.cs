﻿using Application.Commons;
using Application.Filters;
using Application.Models;
using Application.Services.Abstractions;
using Application.Services.GoogleStorage;
using AutoMapper;
using Domain.Entities.Commons;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Application.Services;
public class AssetService : IAssetService
{
    private static readonly string PARENT_FOLDER = "Asset";

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICloudStorageService _cloudStorageService;
    private readonly IClaimService _claimService;

    public AssetService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ICloudStorageService cloudStorageService,
        IClaimService claimService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cloudStorageService = cloudStorageService;
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
        Guid? loginId = _claimService.GetCurrentUserId;

        bool isAccountExisted = await _unitOfWork.AccountRepository.IsExistedAsync(accountId);
        if (!isAccountExisted)
            throw new KeyNotFoundException("Không tìm thấy tài khoản.");

        var listAsset = await _unitOfWork.AssetRepository.GetAllAssetsAsync(
            accountId, criteria.MinPrice, criteria.MaxPrice, criteria.Keyword, criteria.SortColumn, criteria.SortOrder, criteria.PageNumber, criteria.PageSize);
        var listAssetVM = _mapper.Map<PagedList<AssetVM>>(listAsset);

        // check if user is logged in
        if (loginId != null)
        {
            foreach (var asset in listAssetVM.Items)
            {
                var isBought = await _unitOfWork.TransactionHistoryRepository.GetAssetTransactionAsync(loginId.Value, asset.Id);
                asset.IsBought = isBought != null;
            }
        }
        return listAssetVM;
    }

    public async Task<AssetVM> GetAssetByIdAsync(Guid assetId)
    {
        Guid? accountId = _claimService.GetCurrentUserId;

        var asset = await _unitOfWork.AssetRepository.GetByIdAsync(assetId);
        if (asset == null)
            throw new KeyNotFoundException("Không tìm thấy tài nguyên.");
        if (asset.DeletedOn != null)
            throw new KeyNotFoundException("Tài nguyên đã bị xóa.");
        var assetVM = _mapper.Map<AssetVM>(asset);

        // check if user is logged in
        if (accountId != null)
        {
            var isBought = await _unitOfWork.TransactionHistoryRepository.GetAssetTransactionAsync(accountId.Value, assetId);
            assetVM.IsBought = isBought != null;
        }

        return assetVM;
    }

    // lay link download cua asset
    public async Task<string?> GetDownloadUriAssetAsync(Guid assetId)
    {
        var accountId = _claimService.GetCurrentUserId ?? default;
        
        var asset = await _unitOfWork.AssetRepository.GetAssetAndItsCreatorAsync(assetId)
            ?? throw new KeyNotFoundException("Không tìm thấy tài nguyên.");

        if (_claimService.IsModeratorOrAdmin())
            return await _cloudStorageService.GetDownloadSignedUrlFromPrivateCloudStorage(asset.AssetName, PARENT_FOLDER);

        if (asset.Artwork.CreatedBy == accountId)
            return await _cloudStorageService.GetDownloadSignedUrlFromPrivateCloudStorage(asset.AssetName, PARENT_FOLDER);

        // kiem tra xem user da mua asset chua
        var assetTransaction = await _unitOfWork.TransactionHistoryRepository.GetSingleByConditionAsync(
            x => x.AssetId == assetId && x.CreatedBy == accountId && x.Price < 0);
        if (assetTransaction != null)
            return await _cloudStorageService.GetDownloadSignedUrlFromPrivateCloudStorage(asset.AssetName, PARENT_FOLDER);

        if (asset.DeletedOn != null)
            throw new KeyNotFoundException("Tài nguyên đã bị xóa.");

        if (asset.Price > 0)
            throw new UnauthorizedAccessException("Bạn chưa mua tài nguyên này.");

        return await _cloudStorageService.GetDownloadSignedUrlFromPrivateCloudStorage(asset.AssetName, PARENT_FOLDER);
    }

    public async Task<string?> GetDownloadUriAssetForModerationAsync(Guid assetId)
    {
        var asset = await _unitOfWork.AssetRepository.GetAssetAndItsCreatorAsync(assetId);
        if (asset == null)
            throw new KeyNotFoundException("Không tìm thấy tài nguyên.");
        return await _cloudStorageService.GetDownloadSignedUrlFromPrivateCloudStorage(asset.AssetName, PARENT_FOLDER);
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
            throw new KeyNotFoundException("Không tìm thấy tác phẩm.");
        if (artwork.DeletedOn != null)
            throw new KeyNotFoundException("Tác phẩm đã bị xóa.");

        // dat ten lai hinh anh
        string newAssetName = $"{Path.GetFileNameWithoutExtension(assetModel.File.FileName)}_{DateTime.Now.Ticks}";
        string folderName = PARENT_FOLDER;
        string imageExtension = Path.GetExtension(assetModel.File.FileName); // lay duoi file (.zip, .rar, ...)

        // upload asset len cloud, lay url
        var url = await _cloudStorageService.UploadFileToCloudStorage(assetModel.File, newAssetName, folderName, false)
            ?? throw new KeyNotFoundException("Lỗi khi tải tài nguyên lên đám mây.");

        // map assetModel sang asset
        Asset newAsset = _mapper.Map<Asset>(assetModel);
        newAsset.Location = url;
        newAsset.AssetName = newAssetName + imageExtension;
        newAsset.ContentType = imageExtension.Replace(".", "");
        newAsset.Size = (ulong)assetModel.File.Length;

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
            throw new KeyNotFoundException("Không tìm thấy tác phẩm.");
        var allAssetsOfArtwork = await _unitOfWork.AssetRepository.GetListByConditionAsync(x => x.ArtworkId == multiAssetModel.ArtworkId);
        if (allAssetsOfArtwork.Count > 0)
            throw new BadHttpRequestException("Tác phẩm đã có tài nguyên.");
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
        //            throw new KeyNotFoundException("Lỗi khi tải tài nguyên lên đám mây.");

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
            string folderName = PARENT_FOLDER;
            string imageExtension = Path.GetExtension(singleAsset.File.FileName); // lay duoi file (.zip, .rar, ...)

            // upload asset len cloud, lay url
            var url = await _cloudStorageService.UploadFileToCloudStorage(singleAsset.File, newAssetName, folderName, false)
                ?? throw new KeyNotFoundException("Lỗi khi tải tài nguyên lên đám mây.!");
            Asset newAsset = new()
            {
                ArtworkId = multiAssetModel.ArtworkId,
                AssetTitle = singleAsset.AssetTitle,
                Description = singleAsset.Description,
                Price = singleAsset.Price,
                Location = url,
                AssetName = newAssetName + imageExtension,
                ContentType = imageExtension.Replace(".", ""),
                Size = (ulong)singleAsset.File.Length,
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
            throw new KeyNotFoundException("Không tìm thấy tài nguyên.");
        _unitOfWork.AssetRepository.SoftDelete(result);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAssetAsync(Guid assetId, AssetEM assetEM)
    {
        var oldAsset = await _unitOfWork.AssetRepository.GetByIdAsync(assetId);
        if (oldAsset == null)
            throw new KeyNotFoundException("Không tìm thấy tài nguyên.");
        oldAsset.AssetTitle = assetEM.AssetTitle;
        oldAsset.Description = assetEM.Description;
        oldAsset.Price = assetEM.Price;

        _unitOfWork.AssetRepository.Update(oldAsset);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<AssetVM>> GetAllAssetsOfArtworkAsync(Guid artworkId)
    {
        bool isArtworkExisted = await _unitOfWork.ArtworkRepository.IsExistedAsync(artworkId);
        if (!isArtworkExisted)
            throw new KeyNotFoundException("Không tìm thấy tác phẩm.");

        var listAssetOfArtwork = await _unitOfWork.AssetRepository.GetListByConditionAsync(x => x.ArtworkId == artworkId);
        var listAssetVMOfArtwork = _mapper.Map<List<AssetVM>>(listAssetOfArtwork);
        return listAssetVMOfArtwork;
    }

    public async Task<IPagedList<AssetVM>> GetAssetsBoughtOfAccountAsync(Guid accountId, PagedCriteria criteria)
    {
        bool isAccountExisted = await _unitOfWork.AccountRepository.IsExistedAsync(accountId);
        if (!isAccountExisted)
            throw new KeyNotFoundException("Không tìm thấy tài khoản.");

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