using Application.Services;
using Application.Services.Abstractions;
using Domain.Entitites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels.Commons;
using WebApi.ViewModels;
using AutoMapper;

namespace WebApi.Controllers;

//[Route("api/[controller]")]
[ApiController]
public class CollectionsController : ControllerBase
{
    private readonly ICollectionService _collectionService;
    private readonly IMapper _mapper;

    public CollectionsController(ICollectionService collectionService,
        IMapper mapper)
    {
        _collectionService = collectionService;
        _mapper = mapper;
    }

    // GET: api/collections
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
    public async Task<ActionResult<CollectionVM>> GetCollection(Guid id)
    {
        var collection = await _collectionService.GetCollectionDetailAsync(id);
        if (collection == null)
        {
            return NotFound(new ApiResponse { ErrorMessage = "Collection Id not found!" });
        }
        return Ok(_mapper.Map<CollectionVM>(collection));
    }

    //// PUT: api/collections/5    
    //[HttpPut("{id}")]
    //[Authorize]
    //public async Task<IActionResult> PutAccount(Guid id, AccountModel model)
    //{
    //    // check authorize
    //    if (!CheckAuthorize(id))
    //    {
    //        return Forbid();
    //    }
    //    try
    //    {
    //        var oldAcc = await _collectionService.GetAccountByIdAsync(id);
    //        if (oldAcc == null || oldAcc.DeletedOn != null)
    //        {
    //            return NotFound(new ApiResponse { ErrorMessage = "Account id not found." });
    //        }
    //        var account = _mapper.Map<AccountModel, Account>(model, oldAcc);
    //        await _collectionService.UpdateAccountAsync(account);
    //    }
    //    catch (ArgumentException ex)
    //    {
    //        return NotFound(new ApiResponse { ErrorMessage = ex.Message });
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
    //    }

    //    return NoContent();
    //}

    //// POST: api/collections    
    //[HttpPost]
    //[Authorize(Roles = "Admin")]
    //public async Task<ActionResult<Account>> PostAccount(RegisterModel model)
    //{
    //    var account = _mapper.Map<Account>(model);
    //    try
    //    {
    //        await _collectionService.CreateAccountAsync(account);
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
    //    }

    //    return CreatedAtAction("GetAccount", new { id = account.Id }, _mapper.Map<AccountVM>(account));
    //}

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
            return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
        }

        return NoContent();
    }    
}
