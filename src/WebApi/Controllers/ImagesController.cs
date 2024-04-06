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
using WebApi.ViewModels.Commons;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public ImagesController(IImageService imageService, IMapper mapper)
        {
            _imageService = imageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            var result = await _imageService.GetAllImagesAsync();
            return Ok(result);
        }

        [HttpGet("{imageId}/duplication")]
        public async Task<IActionResult> GetImagesDuplicate(Guid imageId)
        {
            try
            {
                var result = await _imageService.GetImagesDuplicateAsync(imageId);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ApiResponse { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
            }
        }

        [HttpGet("{imageId}")]
        public async Task<IActionResult> GetImageById(Guid imageId)
        {
            try
            {
                var result = await _imageService.GetImageByIdAsync(imageId);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ApiResponse { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
            }
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
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
            }
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
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
            }
        }

        [HttpDelete("{imageId}")]
        [Authorize]
        public async Task<IActionResult> DeleteImage(Guid imageId)
        {
            try
            {
                await _imageService.DeleteImageAsync(imageId);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ApiResponse { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
            }
        }
    }
}
