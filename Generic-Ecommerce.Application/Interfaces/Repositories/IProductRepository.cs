using Generic_Ecommerce.Domain.Entities;

namespace Generic_Ecommerce.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(Guid id);
        
        Task<int> GetStockByIdAsync(Guid id);
    }
}
