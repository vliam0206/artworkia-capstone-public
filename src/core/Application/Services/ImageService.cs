using Application.Models;
using Application.Services.Abstractions;
using Application.Services.Firebase;
using AutoMapper;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;
public class ImageService : IImageService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFirebaseService _firebaseService;
    private readonly IMapper _mapper;

    public ImageService(IUnitOfWork unitOfWork, IFirebaseService firebaseService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _firebaseService = firebaseService;
        _mapper = mapper;
    }

    public async Task<List<Image>> GetAllImagesAsync()
    {
        return await _unitOfWork.ImageRepository.GetAllAsync();
    }

    public async Task<Image?> GetImageByIdAsync(Guid imageId)
    {
        var result = await _unitOfWork.ImageRepository.GetByIdAsync(imageId);
        return result;
    }

    public Task<List<Image>> GetAllImagesOfArtworkAsync(Guid artworkId)
    {
        var result = _unitOfWork.ImageRepository.GetListByConditionAsync(x => x.ArtworkId == artworkId);
        return result;
    }

    // lay so thu tu lon nhat cua hinh anh trong artwork
    private async Task<int> GetLatestOrderOfImageInArtwork(Guid artworkId)
    {
        var allImagesOfArtwork = await _unitOfWork.ImageRepository.GetListByConditionAsync(x => x.ArtworkId == artworkId);
        return allImagesOfArtwork.Count;
    }

    public async Task AddImageAsync(ImageModel imageModel)
    {
        // kiem tra artwork co ton tai khong
        bool IsArtworkExisted = await _unitOfWork.ArtworkRepository.IsExisted(imageModel.ArtworkId);
        if (!IsArtworkExisted)
            throw new NullReferenceException("Artwork that contains this image does not exist!");

        // lay stt cua hinh anh, dat ten lai hinh anh
        int latestOrder = await GetLatestOrderOfImageInArtwork(imageModel.ArtworkId);
        string newImageName = imageModel.ArtworkId + "_i" + latestOrder;
        string imageExtension = Path.GetExtension(imageModel.Image.FileName); // lay duoi file (.png, .jpg, ...)

        //upload hinh anh len firebase, lay url
        var url = await _firebaseService.UploadFileToFirebaseStorage(imageModel.Image, newImageName, "Image");
        if (url == null)
            throw new Exception("Cannot upload image to firebase");

        // luu thong tin hinh anh vao database
        Image image = _mapper.Map<Image>(imageModel);
        image.Location = url;
        image.ImageName = newImageName + imageExtension;
        image.Order = latestOrder;
        await _unitOfWork.ImageRepository.AddAsync(image);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task AddRangeImageAsync(MultiImageModel multiImageModel)
    {
        // kiem tra artwork co ton tai khong
        bool IsArtworkExisted = await _unitOfWork.ArtworkRepository.IsExisted(multiImageModel.ArtworkId);
        if (!IsArtworkExisted)
            throw new NullReferenceException("Artwork that contains this image does not exist!");

        // chi cho phep upload nhieu hinh anh cho artwork moi tao
        var listImage = await _unitOfWork.ImageRepository.GetListByConditionAsync(x => x.ArtworkId == multiImageModel.ArtworkId);
        if (listImage.Count > 0)
            throw new Exception("Artwork already has images, cannot add multiple images again! (This API only allows adding for the first time)");

        foreach (var singleImage in multiImageModel.Images.Select((image, index) => (image, index)))
        {
            string newImageName = multiImageModel.ArtworkId + "_i" + singleImage.index;
            string imageExtension = Path.GetExtension(singleImage.image.FileName); // lay duoi file (.png, .jpg, ...)

            //upload hinh anh len firebase, lay url
            var url = await _firebaseService.UploadFileToFirebaseStorage(singleImage.image, newImageName, "Image");
            if (url == null)
                throw new Exception("Error when uploading images to firebase");

            // luu thong tin hinh anh vao database
            Image image = new Image()
            {
                ArtworkId = multiImageModel.ArtworkId,
                Location = url,
                ImageName = newImageName + imageExtension,
                Order = singleImage.index
            };
            await _unitOfWork.ImageRepository.AddAsync(image);
        }
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteImageAsync(Guid imageId)
    {
        var result = await _unitOfWork.ImageRepository.GetByIdAsync(imageId);
        if (result == null)
            throw new NullReferenceException("Cannot found image!");

        await _firebaseService.DeleteFileInFirebaseStorage(result.ImageName, "Image");
        _unitOfWork.ImageRepository.Delete(result);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateImageAsync(Image image)
    {
        _unitOfWork.ImageRepository.Update(image);
        await _unitOfWork.SaveChangesAsync();
    }

    
}
