using Application.Services;
using Application.Services.Abstractions;
using Domain.Entitites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels.Commons;
using WebApi.ViewModels;
using AutoMapper;
using Application.Models;

namespace WebApi.Controllers;

[ApiController]
public class CollectionsController : ControllerBase
{
    private readonly ICollectionService _collectionService;
    private readonly IMapper _mapper;
    private readonly IClaimService _claimService;

    public CollectionsController(ICollectionService collectionService,
        IMapper mapper,
        IClaimService claimService)
    {
        _collectionService = collectionService;
        _mapper = mapper;
        _claimService = claimService;
    }

    // GET: api/account/5/collections
    [Route("api/account/{accountId}/[controller]")]
    [HttpGet]    
    public async Task<ActionResult<IEnumerable<CollectionVM>>> GetAllCollections(Guid accountId)
    {
        try
        {
            var collections = await _collectionService
                        .GetAllCollectionsOfAccountAsync(accountId);

            return Ok(_mapper.Map<List<CollectionVM>>(collections));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
        }
    }

    // GET: api/collections/5
    [Route("api/[controller]/{id}")]
    [HttpGet]
    public async Task<ActionResult<CollectionDetailVM>> GetCollection(Guid id)
    {
        var collection = await _collectionService.GetCollectionDetailAsync(id);
        if (collection == null)
        {
            return NotFound(new ApiResponse { ErrorMessage = "Collection Id not found!" });
        }
        return Ok(_mapper.Map<CollectionDetailVM>(collection));
    }    

    // POST: api/collections
    [Route("api/[controller]")]
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<CollectionDetailVM>> PostCollection(CollectionCreationModel model)
    {
        // check enum value
        //...
        // add collection
        var collection = _mapper.Map<Collection>(model);        
        try
        {            
            await _collectionService.CreateCollectionAsync(collection, model.ArtworkId);
            collection = await _collectionService.GetCollectionDetailAsync(collection.Id);
            if (collection == null)
            {
                return StatusCode(500, new ApiResponse { ErrorMessage = "Server failed to create collection!" });
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse { ErrorMessage = ex.Message });
        }

        return CreatedAtAction("GetCollection", new { id = collection.Id }, _mapper.Map<CollectionDetailVM>(collection));
    }

    // PUT: api/collections/5
    [Route("api/[controller]/{id}")]
    [HttpPut]
    [Authorize]
    public async Task<ActionResult<CollectionVM>> PutCollection(Guid id, CollectionModificationModel model)
    {
        // check whether enum value valid
        //...
        // Update collection
        var collection = new Collection();
        try
        {
            await _collectionService.UpdateCollectionAsync(id, model);
            collection = await _collectionService.GetCollectionDetailAsync(id);
        }
        catch (ArgumentException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (UnauthorizedAccessException)
        {
            return Forbid();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse { ErrorMessage = ex.Message });
        }

        return Ok(_mapper.Map<CollectionVM>(collection));
    }

    // DELETE: api/collections/5
    [Route("api/[controller]/{id}")]
    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeleteCollection(Guid id)
    {
        try
        {
            await _collectionService.DeleteCollectionAsync(id);
        }
        catch (ArgumentException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse { ErrorMessage = ex.Message });
        }

        return NoContent();
    }

    // POST: api/collections/5/add-artwork
    [Route("api/[controller]/{id}/artwork")]
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<CollectionVM>> AddArtworkToCollection(Guid id, BookmarkModel model)
    {        
        try
        {
            await _collectionService.AddArtworkToCollectionAsync(new Bookmark
            {
                CollectionId = id,
                ArtworkId = model.ArtworkId
            });
        }
        catch (ArgumentException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (UnauthorizedAccessException)
        {
            return Forbid();
        }
        catch (BadHttpRequestException ex)
        {
            return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse { ErrorMessage = ex.Message });
        }

        return Ok(new ApiResponse { IsSuccess = true });
    }

    // DELETE: api/collections/5/artwork
    [Route("api/[controller]/{id}/artwork")]
    [HttpDelete]
    [Authorize]
    public async Task<ActionResult<CollectionVM>> RemoveArtworkFromCollection(Guid id, BookmarkModel model)
    {
        try
        {
            await _collectionService.RemoveArtworkFromCollectionAsync(new Bookmark
            {
                CollectionId = id,
                ArtworkId = model.ArtworkId
            });
        }
        catch (ArgumentException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (UnauthorizedAccessException)
        {
            return Forbid();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse { ErrorMessage = ex.Message });
        }

        return NoContent();
    }
}
