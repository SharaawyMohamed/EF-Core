using Core.Services;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace OrderSystem.Settings.Controllers
{
    [Authorize]

    public class ProductController : ApiBaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productRepository)
        {
            _productService = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            if (!products.Any())
            {
                return BadRequest("There is no products to displayed");
            }
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult> GetProductById(int productId)
        {
            var product =  await (_productService.GetProductById(productId))!;
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] ProductDto product)
        {
            if (product == null)
            {
                return BadRequest();
            }
          return !await _productService.AddProduct(product)?BadRequest(): Ok("Product Added Successfully");
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{productId}")]
        public async Task<ActionResult> UpdateProduct(int productId, [FromBody] ProductDto product)
        {

            return !await _productService.UpdateProduct(productId, product) ? BadRequest("Invalid Product Id Or Product Details") : Ok("Product Successfully Updated");
        }
    }
}
