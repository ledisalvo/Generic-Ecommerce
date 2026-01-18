using Generic_Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Ecommerce.Infrastructure.Persistense
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Order> Orders => Set<Order>();
        //public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Customer> Customers => Set<Customer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ApplicationDbContext).Assembly);

            modelBuilder.Ignore<OrderItem>();

            modelBuilder.Entity<Order>(order =>
            {
                order.HasKey(o => o.Id);

                order.OwnsMany(o => o.OrderItems, item =>
                {
                    item.WithOwner().HasForeignKey("OrderId");

                    item.Property<Guid>("Id");
                    item.HasKey("Id");

                    item.Property(i => i.UnitPrice).HasPrecision(18, 2);
                });
            });
        }
    }

}
