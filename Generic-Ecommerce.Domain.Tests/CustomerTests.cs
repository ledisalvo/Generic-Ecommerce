using FluentAssertions;
using Generic_Ecommerce.Domain.Entities;
using Generic_Ecommerce.Domain.Exceptions;

namespace Generic_Ecommerce.Domain.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void CreateCustomer_WithValidData_ShouldCreateCustomer()
        {
            // Act
            var customer = new Customer(
                "Leo",
                "leo@test.com",
                "123456"
            );

            // Assert
            customer.Id.Should().NotBeEmpty();
            customer.Name.Should().Be("Leo");
            customer.Email.Should().Be("leo@test.com");
            customer.PhoneNumber.Should().Be("123456");
        }

        [Fact]
        public void CreateCustomer_WithEmptyName_ShouldThrowDomainException()
        {
            // Act
            var act = () => new Customer(
                "",
                "leo@test.com",
                null
            );

            // Assert
            act.Should().Throw<DomainException>()
               .WithMessage("El nombre del cliente está vacío y es requerido.");
        }

        [Fact]
        public void CreateCustomer_WithEmptyEmail_ShouldThrowDomainException()
        {
            // Act
            var act = () => new Customer(
                "Leo",
                "",
                null
            );

            // Assert
            act.Should().Throw<DomainException>()
               .WithMessage("El email del cliente está vacio y es un campo requerido");
        }
    }
}
