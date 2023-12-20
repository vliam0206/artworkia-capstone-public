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
    public class AssetsController : ControllerBase
    {
        private readonly IAssetService _assetService;
        private readonly IMapper _mapper;
        public AssetsController(IAssetService assetService, IMapper mapper)
        {
            _assetService = assetService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAssets()
        {
            var result = await _assetService.GetAllAssetsAsync();
            return Ok(result);
        }
        [HttpGet("{assetId}")]
        public async Task<IActionResult> GetAssetById(Guid assetId)
        {
            var result = await _assetService.GetAssetByIdAsync(assetId);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsset([FromBody] AssetModel assetModel)
        {
            Asset asset;
            if (assetModel == null)
                return BadRequest();
            try
            {
                asset = _mapper.Map<Asset>(assetModel);
                await _assetService.AddAssetAsync(asset);

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{assetId}")]
        public async Task<IActionResult> DeleteAsset(Guid assetId)
        {
            await _assetService.DeleteAssetAsync(assetId);
            return Ok();
        }
    }
}
