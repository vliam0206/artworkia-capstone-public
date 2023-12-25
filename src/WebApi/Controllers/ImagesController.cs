using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
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

        [HttpGet("{imageId}")]
        public async Task<IActionResult> GetImageById(Guid imageId)
        {
            var result = await _imageService.GetImageByIdAsync(imageId);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddImage([FromBody] ImageModel imageModel)
        {
            Image image;
            if (imageModel == null)
                return BadRequest();
            try
            {
                image = _mapper.Map<Image>(imageModel);
                await _imageService.AddImageAsync(image);

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{imageId}")]
        public async Task<IActionResult> DeleteImage(Guid imageId)
        {
            try
            {
                await _imageService.DeleteImageAsync(imageId);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{imageId}")]
        public async Task<IActionResult> UpdateImage(Guid imageId, [FromBody] ImageModel imageModel)
        {
            Image image;
            if (imageModel == null)
                return BadRequest();
            try
            {
                image = _mapper.Map<Image>(imageModel);
                await _imageService.UpdateImageAsync(image);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
