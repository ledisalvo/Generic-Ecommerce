using Generic_Ecommerce.Domain.Entities;

namespace Generic_Ecommerce.Application.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task<Order?> GetByIdAsync(Guid id);
        Task UpdateAsync(Order order);
        Task<List<Order>> GetByCustomerIdAsync(Guid customerId);
    }
}
