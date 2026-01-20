//using FluentAssertions;
//using Generic_Ecommerce.Application.Exceptions;
//using Generic_Ecommerce.Application.Features.Customer.CreateCustomer;
//using Generic_Ecommerce.Application.Interfaces.Repositories;
//using Generic_Ecommerce.Domain.Entities;
//using Moq;

//namespace Generic_Ecommerce.Application.Tests
//{
//    public class CreateCustomerHandlerTests
//    {
//        private readonly Mock<ICustomerRepository> _repository;
//        private readonly CreateCustomerHandler _handler;

//        public CreateCustomerHandlerTests()
//        {
//            _repository = new Mock<ICustomerRepository>();
//            _handler = new CreateCustomerHandler(_repository.Object);
//        }

//        [Fact]
//        public async Task Handle_ValidCommand_ShouldCreateCustomer()
//        {
//            // Arrange
//            var command = new CreateCustomerCommand(Guid.NewGuid(), "Leo", "leo@gmail.com", "1111111");

//            // Act
//            var result = await _handler.Handle(command, CancellationToken.None);

//            // Assert
//            result.IsSuccess.Should().BeTrue();
//            result.Value.Should().NotBeEmpty();

//            _repository.Verify(
//                r => r.AddAsync(It.IsAny<Customer>()),
//                Times.Once
//            );
//        }
//    }

//}