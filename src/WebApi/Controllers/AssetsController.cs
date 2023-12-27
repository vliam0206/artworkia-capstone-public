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
    public class AssetsController : ControllerBase
    {
        private readonly IAssetService _assetService;
        private readonly IFirebaseService _firebaseService;
        private readonly IMapper _mapper;

        public AssetsController(IFirebaseService firebaseService, IAssetService assetService, IMapper mapper)
        {
            _firebaseService = firebaseService;
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
        [Authorize]
        public async Task<IActionResult> AddAsset([FromForm] AssetModel assetModel)
        {
            Asset asset;
            if (assetModel == null)
                return BadRequest();
            try
            {
                string assetName = Guid.NewGuid().ToString();   
                var url = await _firebaseService.UploadFileToFirebaseStorage(assetModel.File, assetName, "Asset");
                if (url == null)
                    return BadRequest("Cannot upload asset");
                asset = _mapper.Map<Asset>(assetModel);
                asset.Location = url;
                //asset.AssetName = assetName;
                await _assetService.AddAssetAsync(asset);

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{assetId}")]
        [Authorize]
        public async Task<IActionResult> UpdateAsset(Guid assetId, [FromForm] AssetModel assetModel)
        {
            Asset asset;
            if (assetModel == null)
                return BadRequest();
            try
            {
                asset = _mapper.Map<Asset>(assetModel);
                await _assetService.UpdateAssetAsync(asset);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{assetId}")]
        [Authorize]
        public async Task<IActionResult> DeleteAsset(Guid assetId)
        {
            await _assetService.DeleteAssetAsync(assetId);
            return Ok();
        }
    }
}
