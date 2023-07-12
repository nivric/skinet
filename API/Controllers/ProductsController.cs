
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private IRepository _repository;
        public ProductsController(IRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
          return Ok(await _repository.GetAllProducts());
        }

        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
           return "a product";
        }
    }

}