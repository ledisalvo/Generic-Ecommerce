//using Generic_Ecommerce.Application.Features.Customer.GetCustomerById;
//using Generic_Ecommerce.Application.Interfaces.Repositories;
//using Generic_Ecommerce.Domain.Entities;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Generic_Ecommerce.Application.Tests
//{
//    public class GetCustomerByIdHandlerTests
//    {
//        private readonly Mock<ICustomerRepository> _repository;
//        private readonly GetCustomerByIdHandler _handler;

//        public GetCustomerByIdHandlerTests()
//        {
//            _repository = new Mock<ICustomerRepository>();
//            _handler = new GetCustomerByIdHandler(_repository.Object);
//        }

//        [Fact]
//        public async Task Handle_CustomerExists_ShouldReturnCustomer()
//        {
//            // Arrange
//            var customer = new Customer("Leo", "leo@test.com", null);

//            _repository
//                .Setup(r => r.GetByIdAsync(customer.Id))
//                .ReturnsAsync(customer);

//            var query = new GetCustomerByIdQuery(customer.Id);

//            // Act
//            var result = await _handler.Handle(query, CancellationToken.None);

//            // Assert
//            result.IsSuccess.Should().BeTrue();
//            result.Value.Id.Should().Be(customer.Id);
//        }

//        [Fact]
//        public async Task Handle_CustomerDoesNotExist_ShouldReturnFailure()
//        {
//            // Arrange
//            var query = new GetCustomerByIdQuery(Guid.NewGuid());

//            _repository
//                .Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
//                .ReturnsAsync((Customer?)null);

//            // Act
//            var result = await _handler.Handle(query, CancellationToken.None);

//            // Assert
//            result.IsSuccess.Should().BeFalse();
//        }
//    }
//}
