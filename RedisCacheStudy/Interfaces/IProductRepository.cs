using RedisCacheStudy.Models;

namespace RedisCacheStudy.Interfaces
{
    public interface IProductRepository
    {
        Product? GetProductById(int id);
        void AddProduct(Product product);
    }
}
