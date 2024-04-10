using Application.Commons;
using Application.Filters;
using Application.Models;
using Application.Services.Abstractions;
using Application.Services.Firebase;
using AutoMapper;
using Domain.Entities.Commons;
using Domain.Entitites;
using Domain.Enums;
using Domain.Repositories.Abstractions;
using Microsoft.AspNetCore.Http;
using static Application.Commons.VietnameseEnum;

namespace Application.Services;

public class ArtworkService : IArtworkService
{
    private static readonly string PARENT_FOLDER = "Artwork";
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageService _imageService;
    private readonly ITagDetailService _tagDetailService;
    private readonly ISoftwareDetailService _softwareDetailService;
    private readonly ICategoryArtworkDetailService _categoryArtworkDetailService;
    private readonly IFirebaseService _firebaseService;
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;
    public ArtworkService(
        IUnitOfWork unitOfWork,
        IImageService imageService,
        ITagDetailService tagDetailService,
        ISoftwareDetailService softwareDetailService,
        ICategoryArtworkDetailService catworkDetailService,
        IFirebaseService firebaseService,
        IClaimService claimService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _imageService = imageService;
        _tagDetailService = tagDetailService;
        _softwareDetailService = softwareDetailService;
        _categoryArtworkDetailService = catworkDetailService;
        _firebaseService = firebaseService;
        _claimService = claimService;
        _mapper = mapper;
    }

    public async Task<IPagedList<ArtworkPreviewVM>> GetArtworksAsync(ArtworkCriteria criteria)
    {
        Guid? loginId = _claimService.GetCurrentUserId;

        var listArtwork = await _unitOfWork.ArtworkRepository.GetArtworksAsync(
            criteria.Keyword, criteria.SortColumn,
            criteria.SortOrder, criteria.PageNumber, criteria.PageSize,
            null, criteria.CategoryId, criteria.TagId);
        var listArtworkPreviewVM = _mapper.Map<PagedList<ArtworkPreviewVM>>(listArtwork);

        // check if user login liked artworks
        if (loginId != null)
        {
            foreach (var artworkPreviewVM in listArtworkPreviewVM.Items)
            {
                var isLiked = await _unitOfWork.LikeRepository.GetByIdAsync(loginId.Value, artworkPreviewVM.Id);
                artworkPreviewVM.IsLiked = isLiked != null;
            }
        }

        return listArtworkPreviewVM;
    }

    public async Task<IPagedList<ArtworkModerationVM>> GetAllArtworksForModerationAsync(ArtworkModerationCriteria criteria)
    {
        var listArtwork = await _unitOfWork.ArtworkRepository.GetArtworksForModerationAsync(
            criteria.Keyword, criteria.SortColumn,
            criteria.SortOrder, criteria.PageNumber, criteria.PageSize,
            null, criteria.CategoryId, criteria.TagId, criteria.State, criteria.Privacy);
        var listArtworkModerationVM = _mapper.Map<PagedList<ArtworkModerationVM>>(listArtwork);
        return listArtworkModerationVM;
    }

    public async Task<IPagedList<ArtworkPreviewVM>> GetAllArtworksByAccountIdAsync(Guid accountId, ArtworkModerationCriteria criteria)
    {
        Guid? loginId = _claimService.GetCurrentUserId;

        bool isAccountExist = await _unitOfWork.AccountRepository.IsExistedAsync(accountId);
        if (!isAccountExist)
            throw new KeyNotFoundException("Không tìm thấy tài khoản.");

        var listArtwork = await _unitOfWork.ArtworkRepository.GetArtworksAsync(
            criteria.Keyword, criteria.SortColumn,
            criteria.SortOrder, criteria.PageNumber, criteria.PageSize,
            accountId, criteria.CategoryId, criteria.TagId, criteria.State, criteria.Privacy);
        var listArtworkPreviewVM = _mapper.Map<PagedList<ArtworkPreviewVM>>(listArtwork);

        // check if user login liked artworks
        if (loginId != null)
        {
            foreach (var artworkPreviewVM in listArtworkPreviewVM.Items)
            {
                var isLiked = await _unitOfWork.LikeRepository.GetByIdAsync(loginId.Value, artworkPreviewVM.Id);
                artworkPreviewVM.IsLiked = isLiked != null;
            }
        }
        return listArtworkPreviewVM;
    }

    public async Task<IPagedList<ArtworkPreviewVM>> GetArtworksOfFollowingsAsync(PagedCriteria criteria)
    {
        Guid followerId = _claimService.GetCurrentUserId ?? default;
        var listArtwork = await _unitOfWork.ArtworkRepository.GetArtworksOfFollowingsAsync(
            followerId, criteria.PageNumber, criteria.PageSize);
        var listArtworkPreviewVM = _mapper.Map<PagedList<ArtworkPreviewVM>>(listArtwork);

        // check if user liked artworks
        foreach (var artworkPreviewVM in listArtworkPreviewVM.Items)
        {
            var isLiked = await _unitOfWork.LikeRepository.GetByIdAsync(followerId, artworkPreviewVM.Id);
            artworkPreviewVM.IsLiked = isLiked != null;
        }

        return listArtworkPreviewVM;
    }

    public async Task<IPagedList<ArtworkContainAssetVM>> GetArtworksContainAssetsOfAccountAsync(Guid accountId, PagedCriteria criteria)
    {
        var listArtwork = await _unitOfWork.ArtworkRepository.GetArtworksContainAssetsOfAccountAsync(
            accountId, criteria.PageNumber, criteria.PageSize);
        var listArtworkVM = _mapper.Map<PagedList<ArtworkContainAssetVM>>(listArtwork);
        return listArtworkVM;
    }

    public async Task<List<ImageDuplicationVM>> GetArtworksDuplicateAsync(Guid artworkId)
    {
        var isExisted = await _unitOfWork.ArtworkRepository.IsExistedAsync(artworkId);
        if (!isExisted)
            throw new KeyNotFoundException("Không tìm thấy tác phẩm.");
        var listArtwork = await _unitOfWork.ArtworkRepository.GetArtworksDuplicateAsync(artworkId);
        var listArtworkVM = _mapper.Map<List<ImageDuplicationVM>>(listArtwork);
        return listArtworkVM;
    }

    public async Task<ArtworkVM?> GetArtworkByIdAsync(Guid artworkId)
    {
        Guid? accountId = _claimService.GetCurrentUserId;

        var artwork = await _unitOfWork.ArtworkRepository.GetArtworkDetailByIdAsync(artworkId) 
            ?? throw new KeyNotFoundException("Không tìm thấy tác phẩm.");
        if (artwork.DeletedOn != null)
            throw new KeyNotFoundException("Tác phẩm đã bị xóa.");

        var artworkVM = _mapper.Map<ArtworkVM>(artwork);

        // check if user is logged in
        if (accountId != null)
        {
            // check if account is blocking or blocked
            if (await _unitOfWork.BlockRepository.IsBlockedOrBlockingAsync(accountId.Value, artworkVM.CreatedBy!.Value))
            {
                throw new BadHttpRequestException("Không tìm thấy tác phẩm vì chặn hoặc bị chặn.");
            }
            // check if user liked this artwork
            var isLiked = await _unitOfWork.LikeRepository.GetByIdAsync(accountId.Value, artworkId);
            artworkVM.IsLiked = isLiked != null;
        }

        // increase view count
        artwork.ViewCount++;
        _unitOfWork.ArtworkRepository.Update(artwork);
        await _unitOfWork.SaveChangesAsync();

        return artworkVM;
    }

    public async Task<ArtworkDetailModerationVM?> GetArtworkByIdForModerationAsync(Guid artworkId)
    {
        var artwork = await _unitOfWork.ArtworkRepository.GetArtworkDetailByIdAsync(artworkId) 
            ?? throw new KeyNotFoundException("Không tìm thấy tác phẩm.");
        var artworkVM = _mapper.Map<ArtworkDetailModerationVM>(artwork);

        await _unitOfWork.SaveChangesAsync();

        return artworkVM;
    }

    public async Task<ArtworkVM> AddArtworkAsync(ArtworkModel artworkModel)
    {
        var newArtwork = _mapper.Map<Artwork>(artworkModel);
        string newThumbnailName = newArtwork.Id + "_t";
        string folderName = $"{PARENT_FOLDER}/Thumbnail";
        string extension = System.IO.Path.GetExtension(artworkModel.Thumbnail.FileName);
        // them thumbnail image vao firebase
        var url = await _firebaseService.UploadFileToFirebaseStorage(artworkModel.Thumbnail, newThumbnailName, folderName);
        if (url == null)
            throw new Exception("Không thể tải ảnh đại diện (thumbnail) lên đám mây.");
        newArtwork.Thumbnail = url;
        newArtwork.ThumbnailName = newThumbnailName + extension;
        // them artwork 
        await _unitOfWork.ArtworkRepository.AddAsync(newArtwork);

        // them software used
        if (artworkModel.SoftwareUseds != null)
        {
            SoftwareListArtworkModel softwareListArtworkModel = new()
            {
                ArtworkId = newArtwork.Id,
                SoftwareList = artworkModel.SoftwareUseds
            };
            await _softwareDetailService.AddSoftwareListArtworkAsync(softwareListArtworkModel, false);
        }

        // them tag 
        TagListArtworkModel tagListArtworkModel = new()
        {
            ArtworkId = newArtwork.Id,
            TagList = artworkModel.Tags
        };
        await _tagDetailService.AddTagListArtworkAsync(tagListArtworkModel, false);

        // them cate
        CategoryListArtworkModel categoryList = new()
        {
            ArtworkId = newArtwork.Id,
            CategoryList = artworkModel.Categories
        };
        await _categoryArtworkDetailService.AddCategoryListArtworkAsync(categoryList, false);

        // them hinh anh
        MultiImageModel multiImageModel = new()
        {
            ArtworkId = newArtwork.Id,
            Images = artworkModel.ImageFiles
        };
        await _imageService.AddRangeImageAsync(multiImageModel, false);

        bool flagPrice = false;
        // them asset
        if (artworkModel.AssetFiles != null)
        {
            var uploadAssetsTask = new List<Task>();
            foreach (var singleAsset in artworkModel.AssetFiles.Select((file, index) => (file, index)))
            {
                if (flagPrice == false && singleAsset.file.Price > 0)
                {
                    flagPrice = true;
                }

                string newAssetName = $"{Path.GetFileNameWithoutExtension(singleAsset.file.File.FileName)}_{DateTime.Now.Ticks}";
                string assetFolderName = $"{PARENT_FOLDER}/Asset";
                string imageExtension = Path.GetExtension(singleAsset.file.File.FileName);

                // upload asset len firebase, lay url
                uploadAssetsTask.Add(Task.Run(async () =>
                {
                    var url = await _firebaseService.UploadFileToFirebaseStorage(singleAsset.file.File, newAssetName, assetFolderName);
                    if (url == null)
                        throw new Exception("Không thể tải tài nguyên lên đám mây.");

                    Asset newAsset = new()
                    {
                        ArtworkId = newArtwork.Id,
                        Location = url,
                        AssetName = newAssetName + imageExtension,
                        AssetTitle = singleAsset.file.AssetTitle,
                        Description = singleAsset.file.Description,
                        Price = singleAsset.file.Price,
                        ContentType = imageExtension.Replace(".", ""),
                        Size = (ulong) singleAsset.file.File.Length
                };
                    await _unitOfWork.AssetRepository.AddAsync(newAsset);
                }));
            }
            await Task.WhenAll(uploadAssetsTask);
        }

        if (flagPrice)
            newArtwork.State = StateEnum.Waiting;
        else
            newArtwork.State = StateEnum.Accepted;

        await _unitOfWork.SaveChangesAsync();
        var result = await _unitOfWork.ArtworkRepository.GetArtworkDetailByIdAsync(newArtwork.Id);
        return _mapper.Map<ArtworkVM>(result);
    }

    public async Task DeleteArtworkAsync(Guid artworkId)
    {
        // check if artwork exist
        var artwork = await _unitOfWork.ArtworkRepository.GetByIdAsync(artworkId);
        if (artwork == null)
            throw new Exception("Không tìm thấy tác phẩm.");

        // check authorized
        if (_claimService.GetCurrentRole.Equals(RoleEnum.CommonUser.ToString()) &&
            artwork.CreatedBy != _claimService.GetCurrentUserId)
        {
            throw new UnauthorizedAccessException("Bạn không có quyền xóa tác phẩm.");
        }
        _unitOfWork.ArtworkRepository.Delete(artwork);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task SoftDeleteArtworkAsync(Guid artworkId)
    {
        var artwork = await _unitOfWork.ArtworkRepository.GetByIdAsync(artworkId);
        if (artwork == null)
            throw new Exception("Không tìm thấy tác phẩm.");

        // check authorized
        if (_claimService.GetCurrentRole.Equals(RoleEnum.CommonUser.ToString()) &&
            artwork.CreatedBy != _claimService.GetCurrentUserId)
        {
            throw new UnauthorizedAccessException("Bạn không có quyền xóa tác phẩm.");
        }
        _unitOfWork.ArtworkRepository.SoftDelete(artwork);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateArtworkAsync(Guid artworkId, ArtworkEM artworkEM)
    {
        var oldArtwork = await _unitOfWork.ArtworkRepository.GetByIdAsync(artworkId);
        if (oldArtwork == null)
            throw new KeyNotFoundException("Không tìm thấy tác phẩm.");

        oldArtwork.Title = artworkEM.Title;
        oldArtwork.Description = artworkEM.Description;
        oldArtwork.Privacy = artworkEM.Privacy;
        // chua update AI, thumbnail, imagefiles, tags, categories
        _unitOfWork.ArtworkRepository.Update(oldArtwork);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateArtworkStateAsync(Guid artworkId, ArtworkStateEM model)
    {
        var oldArtwork = await _unitOfWork.ArtworkRepository.GetByIdAsync(artworkId);
        if (oldArtwork == null)
            throw new KeyNotFoundException("Không tìm thấy tác phẩm.");
        if (oldArtwork.State != StateEnum.Waiting)
            throw new BadHttpRequestException($"Tác phẩm đã được xử lý (trạng thái hiện tại là '{STATE_ENUM_VN[oldArtwork.State]}')");
        oldArtwork.State = model.State;
        oldArtwork.Note = model.Note;
        _unitOfWork.ArtworkRepository.Update(oldArtwork);
        await _unitOfWork.SaveChangesAsync();
    }
}
