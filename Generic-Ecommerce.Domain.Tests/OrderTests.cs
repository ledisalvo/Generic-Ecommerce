using FluentAssertions;
using Generic_Ecommerce.Domain.Entities;
using Generic_Ecommerce.Domain.Exceptions;

namespace Generic_Ecommerce.Domain.Tests
{
    public class OrderTests
    {
        [Fact]
        public void CreateOrder_WithValidCustomer_ShouldCreateOrder()
        {
            // Act
            var order = new Order(Guid.NewGuid());

            // Assert
            order.Id.Should().NotBeEmpty();
            order.OrderItems.Should().BeEmpty();
        }

        [Fact]
        public void CreateOrder_WithEmptyCustomerId_ShouldThrowDomainException()
        {
            // Act
            var act = () => new Order(Guid.Empty);

            // Assert
            act.Should().Throw<DomainException>()
               .WithMessage("El ID del cliente está vacío y es requerido.");
        }

        [Fact]
        public void AddItem_WithValidData_ShouldAddItem()
        {
            // Arrange
            var order = new Order(Guid.NewGuid());
            var productId = Guid.NewGuid();

            // Act
            order.AddItem(productId, 100, 2);

            // Assert
            order.OrderItems.Should().HaveCount(1);
        }

        [Fact]
        public void AddItem_WithInvalidPrice_ShouldThrow()
        {
            var order = new Order(Guid.NewGuid());
            var productId = Guid.NewGuid();

            var act = () => order.AddItem(productId, 0, -1);

            act.Should().Throw<DomainException>()
               .WithMessage("El precio del producto no puede ser negativo.");
        }

        [Fact]
        public void AddItem_WithInvalidQuantity_ShouldThrow()
        {
            var order = new Order(Guid.NewGuid());
            var productId = Guid.NewGuid();

            var act = () => order.AddItem(productId, -100, 0);

            act.Should().Throw<DomainException>()
               .WithMessage("La cantidad de los productos no puede ser negativa.");
        }
    }
}