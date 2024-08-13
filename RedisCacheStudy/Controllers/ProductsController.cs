using Microsoft.AspNetCore.Mvc;
using RedisCacheStudy.Interfaces;
using RedisCacheStudy.Models;

namespace RedisCacheStudy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController(IProductRepository productRepository, IRedisCacheService redisCacheService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var cachedProduct = await redisCacheService.GetCacheValueAsync<Product>($"product:{id}");
            if (cachedProduct != null)
            {
                return Ok(cachedProduct);
            }

            var product = productRepository.GetProductById(id);
            if (product == null)
                return NotFound();

            await redisCacheService.SetCacheValueAsync($"product:{id}", product);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            productRepository.AddProduct(product);
            return Ok();
        }
    }
}
