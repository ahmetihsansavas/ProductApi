using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Entity;
using ProductAPI.Services;
using System.ComponentModel;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("ProductList")]
        public async Task<IActionResult> ProductList() {
            var result = await _productService.Products(); 
            return Ok(result);
        }
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var result = await _productService.CreateProduct(product);
            return Created("", result);
        }
        [HttpPut("EditProduct")]
        public async Task<IActionResult> EditProduct(Product product) { 
           var result= await _productService.EditProduct(product);
            return Ok(result);

        }
        [HttpDelete("DeleteProduct")]
        public bool DeleteProduct(int id) {
           return  _productService.DeleteProduct(id);
        }
    }
}
