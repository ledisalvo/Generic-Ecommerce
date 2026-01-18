using Generic_Ecommerce.Application.Interfaces.Repositories;
using Generic_Ecommerce.Domain.Entities;
using Generic_Ecommerce.Infrastructure.Persistense;

namespace Generic_Ecommerce.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }
    }

}
