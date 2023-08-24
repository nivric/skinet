using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class BuggyController : BaseApiController
{
    private readonly StoreContext _dbContext;

    public BuggyController(StoreContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet("NotFound")]
    public IActionResult GetNotFoundRequest()
    {
        var product = _dbContext.Products.Find(46);
        if (product == null)
        {
            return NotFound(new ApiResponse(404));
        }
        return Ok();
    }

    [HttpGet("BadRequest")]
    public IActionResult GetBadRequest()
    {
       return BadRequest(new ApiResponse(400));
    }


    [HttpGet("ServerError")]
    public IActionResult GetInternalServerError()
    {
        var product = _dbContext.Products.Find(46);
        return Ok(product.ToString());

    }

    [HttpGet("BadRequest/{id}")]
    public IActionResult GetBadRequest(int id)
    {
        var product = _dbContext.Products.Find(46);
        return Ok(product.ToString());

    }




}
