using Generic_Ecommerce.Domain.Entities;

namespace Generic_Ecommerce.Application.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetByCustomerIdAsync(Guid customerId);
    }
}
