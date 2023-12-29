using Application.Services.Abstractions;
using Application.Services.Firebase;
using AutoMapper;
using Domain.Entitites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly IFirebaseService _firebaseService;
        private readonly IMapper _mapper;

        public ImagesController(IImageService imageService, IFirebaseService firebaseService, IMapper mapper)
        {
            _imageService = imageService;
            _firebaseService = firebaseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            var result = await _imageService.GetAllImagesAsync();
            return Ok(result);
        }

        [HttpGet("{imageId}")]
        public async Task<IActionResult> GetImageById(Guid imageId)
        {
            var result = await _imageService.GetImageByIdAsync(imageId);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddImage([FromForm] ImageModel imageModel)
        {
            Image image;
            if (imageModel == null)
                return BadRequest();
            try
            {
                string imageName = imageModel.Image.FileName;
                string imageNameWithoutExtension = Path.GetFileNameWithoutExtension(imageName);
                string imageExtension = Path.GetExtension(imageName);
                var url = await _firebaseService.UploadFileToFirebaseStorage(imageModel.Image, imageNameWithoutExtension, "Image");
                if (url == null)
                    return BadRequest("Cannot upload image to firebase");
                image = _mapper.Map<Image>(imageModel);
                image.Location = url;
                image.ImageName = imageName;
                await _imageService.AddImageAsync(image);

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{imageId}")]
        [Authorize]
        public async Task<IActionResult> DeleteImage(Guid imageId)
        {
            try
            {
                var image = await _imageService.GetImageByIdAsync(imageId);
                if (image == null)
                    return NotFound();
                await _firebaseService.DeleteFileInFirebaseStorage(image.ImageName, "Image");
                await _imageService.DeleteImageAsync(imageId);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
