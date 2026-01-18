using Generic_Ecommerce.Domain.Entities;
using MediatR;

namespace Generic_Ecommerce.Application.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task<Customer> GetByIdAsync(Guid customerId);
        Task<bool> ExistsByEmailAsync(string email);
    }
}
