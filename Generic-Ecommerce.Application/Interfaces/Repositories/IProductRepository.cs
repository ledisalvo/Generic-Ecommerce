using Generic_Ecommerce.Domain.Entities;

namespace Generic_Ecommerce.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product?> GetByIdAsync(Guid id);
        Task AddAsync(Product product);
    }
}
