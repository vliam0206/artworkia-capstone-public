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

namespace Application.Services;

public class ServiceService : IServiceService
{
    private static readonly string PARENT_FOLDER = "Service";
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IClaimService _claimService;
    private readonly IFirebaseService _firebaseService;
    private readonly ICategoryServiceDetailService _categoryArtworkDetailService;

    public ServiceService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IClaimService claimService,
        IFirebaseService firebaseService,
        ICategoryServiceDetailService categoryArtworkDetailService
        )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _claimService = claimService;
        _firebaseService = firebaseService;
        _categoryArtworkDetailService = categoryArtworkDetailService;
    }

    public async Task<IPagedList<ServiceVM>> GetAllServicesAsync(ServiceCriteria criteria)
    {
        var listService = await _unitOfWork.ServiceRepository.GetAllServicesAsync(
            null, criteria.MinPrice, criteria.MaxPrice, criteria.Keyword, criteria.SortColumn, 
            criteria.SortOrder, criteria.PageNumber, criteria.PageSize);
        var listServiceVM = _mapper.Map<PagedList<ServiceVM>>(listService);    
        return listServiceVM;
    }

    public async Task<IPagedList<ServiceVM>> GetServicesOfAccountAsync(Guid accountId, ServiceCriteria criteria)
    {
        var listService = await _unitOfWork.ServiceRepository.GetAllServicesAsync(
            accountId, criteria.MinPrice, criteria.MaxPrice, criteria.Keyword, criteria.SortColumn,
            criteria.SortOrder, criteria.PageNumber, criteria.PageSize);
        var listServiceVM = _mapper.Map<PagedList<ServiceVM>>(listService);
        return listServiceVM;
    }

    public async Task<ServiceVM?> GetServiceByIdAsync(Guid serviceId)
    {
        Guid? accountId = _claimService.GetCurrentUserId;

        var service = await _unitOfWork.ServiceRepository.GetServiceByIdAsync(serviceId);
        if (service == null)
            throw new KeyNotFoundException("Không tìm thấy dịch vụ.");
        if (service.DeletedOn != null)
            throw new Exception("Dịch vụ đã xóa.");

        var serviceVM = _mapper.Map<ServiceVM>(service);

        // check if user is logged in
        if (accountId != null)
        {
            // check if account is blocking or blocked
            if (await _unitOfWork.BlockRepository.IsBlockedOrBlockingAsync(accountId.Value, serviceVM.CreatedBy!.Value))
            {
                throw new Exception("Không thể xem dịch vụ vì chặn hoặc bị chặn.");
            }
        }
        return serviceVM;
    }

    public async Task<ServiceVM> AddServiceAsync(ServiceModel serviceModel)
    {
        Guid creatorId = _claimService.GetCurrentUserId ?? default;
        foreach (var artworkId in serviceModel.ArtworkReference)
        {
            var artworkExistInDb = await _unitOfWork.ArtworkRepository.GetByIdAsync(artworkId);
            if (artworkExistInDb == null)
            {
                throw new KeyNotFoundException($"Không tìm thấy tác phẩm. (ID: {artworkId})");
            }
            if (artworkExistInDb.DeletedOn != null)
            {
                throw new Exception($"Tác phẩm đã bị xóa. (ID: {artworkId})");
            }
            if (artworkExistInDb.CreatedBy != creatorId)
            {
                throw new Exception($"Bạn không sở hữu tác phẩm này. (ID: {artworkId})");
            }
            if (artworkExistInDb.Privacy != PrivacyEnum.Public)
            {
                throw new Exception($"Tác phẩm không ở chế độ công khai. (ID: {artworkId})");
            }
            if (artworkExistInDb.State != StateEnum.Accepted)
            {
                throw new Exception($"Tác phẩm chưa được chấp thuận. (ID: {artworkId}, trạng thái hiện tại: {artworkExistInDb.State})");
            }
        }

        var newService = _mapper.Map<Service>(serviceModel);
        string newThumbnailName = newService.Id + "_t";
        string folderName = $"{PARENT_FOLDER}/Thumbnail";

        // them thumbnail image vao firebase
        var url = await _firebaseService.UploadFileToFirebaseStorage(serviceModel.Thumbnail, newThumbnailName, folderName);
        if (url == null)
            throw new Exception("Không thể tải ảnh đại diện dịch vụ lên đám mây.");
        newService.Thumbnail = url;

        await _unitOfWork.ServiceRepository.AddAsync(newService);

        // them artwork reference
        foreach (Guid artworkId in serviceModel.ArtworkReference)
        {
            ServiceDetail serviceDetail = new()
            {
                ArtworkId = artworkId,
                ServiceId = newService.Id
            };
            await _unitOfWork.ServiceDetailRepository.AddServiceDetailAsync(serviceDetail);
        }

        // them cate
        if (serviceModel.Categories != null)
        {
            CategoryListServiceModel categoryList = new CategoryListServiceModel()
            {
                ServiceId = newService.Id,
                CategoryList = serviceModel.Categories
            };
            await _categoryArtworkDetailService.AddCategoryListServiceAsync(categoryList, false);
        }

        await _unitOfWork.SaveChangesAsync();
        var result = await _unitOfWork.ServiceRepository.GetServiceByIdAsync(newService.Id);
        return _mapper.Map<ServiceVM>(result);
    }

    public async Task DeleteServiceAsync(Guid serviceId)
    {
        var service = await _unitOfWork.ServiceRepository.GetByIdAsync(serviceId);
        if (service == null)
        {
            throw new KeyNotFoundException("Không tìm thấy dịch vụ.");
        }
        _unitOfWork.ServiceRepository.SoftDelete(service);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateServiceAsync(Guid serviceId, ServiceEM serviceEM)
    {
        Guid creatorId = _claimService.GetCurrentUserId ?? default;

        var oldService = await _unitOfWork.ServiceRepository.GetByIdAsync(serviceId);
        if (oldService == null)
        {
            throw new KeyNotFoundException("Không tìm thấy dịch vụ.");
        }

        if (serviceEM.ArtworkReference != null)
        {
            foreach (var artworkId in serviceEM.ArtworkReference)
            {
                var artworkExistInDb = await _unitOfWork.ArtworkRepository.GetByIdAsync(artworkId);
                if (artworkExistInDb == null)
                {
                    throw new KeyNotFoundException($"Không tìm thấy tác phẩm. (ID: {artworkId})");
                }
                if (artworkExistInDb.DeletedOn != null)
                {
                    throw new Exception($"Tác phẩm đã bị xóa. (ID: {artworkId})");
                }
                if (artworkExistInDb.CreatedBy != creatorId)
                {
                    throw new Exception($"Bạn không sở hữu tác phẩm này. (ID: {artworkId})");
                }
                if (artworkExistInDb.Privacy != PrivacyEnum.Public)
                {
                    throw new Exception($"Tác phẩm không ở chế độ công khai. (ID: {artworkId})");
                }
                if (artworkExistInDb.State != StateEnum.Accepted)
                {
                    throw new Exception($"Tác phẩm chưa được chấp thuận. (ID: {artworkId}, trạng thái hiện tại: {artworkExistInDb.State})");
                }
            }
        }

        string newThumbnailName = serviceId + "_t";
        string folderName = $"{PARENT_FOLDER}/Thumbnail";

        // cap nhat thumbnail image vao firebase (neu co)
        if (serviceEM.Thumbnail != null)
        {
            var url = await _firebaseService.UploadFileToFirebaseStorage(serviceEM.Thumbnail, newThumbnailName, folderName);
            if (url == null)
                throw new Exception("Không thể tải ảnh đại diện dịch vụ lên đám mây.");
            oldService.Thumbnail = url;
        }

        oldService.ServiceName = serviceEM.ServiceName;
        oldService.Description = serviceEM.Description;
        oldService.DeliveryTime = serviceEM.DeliveryTime;
        oldService.NumberOfConcept = serviceEM.NumberOfConcept;
        oldService.NumberOfRevision = serviceEM.NumberOfRevision;
        oldService.StartingPrice = serviceEM.StartingPrice;


        if (serviceEM.Categories != null)
        {
            // xoa het category cu va them moi category moi
            await _unitOfWork.CategoryServiceDetailRepository.DeleteAllCategoryServiceByServiceIdAsync(serviceId);
            CategoryListServiceModel categoryList = new()
            {
                ServiceId = oldService.Id,
                CategoryList = serviceEM.Categories
            };
            await _categoryArtworkDetailService.AddCategoryListServiceAsync(categoryList, false);
        }

        if (serviceEM.ArtworkReference != null)
        {
            // xoa het service detail cu va them moi service detail moi
            await _unitOfWork.ServiceDetailRepository.DeleteAllServiceDetailAsync(serviceId);
            foreach (Guid artworkId in serviceEM.ArtworkReference)
            {
                ServiceDetail serviceDetail = new()
                {
                    ArtworkId = artworkId,
                    ServiceId = oldService.Id
                };
                await _unitOfWork.ServiceDetailRepository.AddServiceDetailAsync(serviceDetail);
            }
        }

        _unitOfWork.ServiceRepository.Update(oldService);
        await _unitOfWork.SaveChangesAsync();
    }
}
