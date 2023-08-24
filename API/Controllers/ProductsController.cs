
using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {

        //private IProductRepository _repository;
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductType> productTypeRepo,
            IGenericRepository<ProductBrand> productBrandRepo,
            IMapper mapper)
        {
            _productsRepo = productsRepo;
            _productTypeRepo = productTypeRepo;
            _productBrandRepo = productBrandRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] string sort)
        {
            var spec = new ProductWithProductBrandAndTypeSpecification(sort);
            var products = await _productsRepo.GetItemsWithSpecAsync(spec);
            var productsDto = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductToReturnDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProduct(int id)
        {
            var spec = new ProductWithProductBrandAndTypeSpecification(id);
            var product = await _productsRepo.FindItemWithSpecAsync(id, spec);

            if (product == null) { return NotFound(new ApiResponse(404)); }
            return Ok(_mapper.Map<ProductToReturnDto>(product));
        }


        [HttpGet("brands")]
        public async Task<IActionResult> GetProductBrands()
        {
            return Ok(await _productBrandRepo.GetAllItemsAsync());
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetProductTypes()
        {
            return Ok(await _productTypeRepo.GetAllItemsAsync());
        }
    }

}