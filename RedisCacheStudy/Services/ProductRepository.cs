using RedisCacheStudy.Interfaces;
using RedisCacheStudy.Models;

namespace RedisCacheStudy.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = [];
        public void AddProduct(Product product)
        {
           _products.Add(product);  
        }

        public Product? GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);   
        }
    }
}
