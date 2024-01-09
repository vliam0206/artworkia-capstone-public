using Application.Models;
using Application.Services.Abstractions;
using Application.Services.Firebase;
using AutoMapper;
using Domain.Entitites;
using Domain.Models;
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

        //API upload only 1 image
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddImage([FromForm] ImageModel imageModel)
        {
            if (imageModel == null)
                return BadRequest();
            try
            {
                await _imageService.AddImageAsync(imageModel);

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        //API upload only 1 image
        [HttpPost("multi")]
        [Authorize]
        public async Task<IActionResult> AddRangeImage([FromForm] MultiImageModel multiImageModel)
        {
            if (multiImageModel == null)
                return BadRequest();
            try
            {
                await _imageService.AddRangeImageAsync(multiImageModel);

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
                await _imageService.DeleteImageAsync(imageId);
            } catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
