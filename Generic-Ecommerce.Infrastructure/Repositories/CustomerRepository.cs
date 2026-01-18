using Generic_Ecommerce.Application.Interfaces.Repositories;
using Generic_Ecommerce.Domain.Entities;
using Generic_Ecommerce.Infrastructure.Persistense;
using Microsoft.EntityFrameworkCore;

namespace Generic_Ecommerce.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Customers
                .AnyAsync(c => c.Email == email);
        }

        public async Task<Customer?> GetByIdAsync(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}
