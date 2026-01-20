using Generic_Ecommerce.Application.Exceptions;
using Generic_Ecommerce.Application.Features.Orders.CreateOrder;
using Generic_Ecommerce.Application.Interfaces.Repositories;
using Generic_Ecommerce.Domain.Entities;
using Moq;

namespace Generic_Ecommerce.Application.Tests
{
    public class CreateOrderHandlerTests
    {
        private readonly Mock<ICustomerRepository> _customerRepo = new();
        private readonly Mock<IProductRepository> _productRepo = new();
        private readonly Mock<IOrderRepository> _orderRepo = new();

        private CreateOrderHandler CreateHandler()
            => new(
                _customerRepo.Object,
                _productRepo.Object,
                _orderRepo.Object
            );

        [Fact]
        public async Task Handle_ItemsEmpty_ShouldThrowBusinessException()
        {
            var handler = CreateHandler();

            var command = new CreateOrderCommand(Guid.NewGuid(), new List<CreateOrderItemDto>());

            await Assert.ThrowsAsync<BusinessException>(() =>
                handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_CustomerNotFound_ShouldThrowNotFoundException()
        {
            _customerRepo
                .Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Customer?)null);

            var handler = CreateHandler();
            var orderItems = new List<CreateOrderItemDto>();
            orderItems.Add(new CreateOrderItemDto(Guid.NewGuid(), 1));
            var command = new CreateOrderCommand(Guid.NewGuid(), orderItems);

            await Assert.ThrowsAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ProductNotFound_ShouldThrowNotFoundException()
        {
            _customerRepo
                .Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new Customer("Leo", "leo@gmail.com", "1234"));

            _productRepo
                .Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Product?)null);

            var handler = CreateHandler();

            var orderItems = new List<CreateOrderItemDto>();
            orderItems.Add(new CreateOrderItemDto(Guid.NewGuid(), 1));
            var command = new CreateOrderCommand(Guid.NewGuid(), orderItems);

            await Assert.ThrowsAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ProductOutOfStock_ShouldThrowBusinessException()
        {
            var product = new Product(
                name: "Coca Cola",
                price: 100,
                stockQuantity: 0
            );

            _customerRepo
                .Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new Customer("Leo", "leo@gmail.com", "1234"));

            _productRepo
                .Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(product);

            var handler = CreateHandler();

            var orderItems = new List<CreateOrderItemDto>();
            orderItems.Add(new CreateOrderItemDto(product.Id, 1));
            var command = new CreateOrderCommand(Guid.NewGuid(), orderItems);

            await Assert.ThrowsAsync<BusinessException>(() =>
                handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ValidCommand_ShouldCreateOrderAndReturnId()
        {
            var customerId = Guid.NewGuid();
            var productId = Guid.NewGuid();

            var product = new Product(
                name: "Coca Cola",
                price: 100,
                stockQuantity: 10
            );

            _customerRepo
                .Setup(r => r.GetByIdAsync(customerId))
                .ReturnsAsync(new Customer("Leo", "leo@gmail.com", "1234"));

            _productRepo
                .Setup(r => r.GetByIdAsync(productId))
                .ReturnsAsync(product);

            _orderRepo
                .Setup(r => r.AddAsync(It.IsAny<Order>()))
                .Returns(Task.CompletedTask);

            var handler = CreateHandler();

            var orderItems = new List<CreateOrderItemDto>();
            orderItems.Add(new CreateOrderItemDto(productId, 2));
            var command = new CreateOrderCommand(customerId, orderItems);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.True(result.Success);
            Assert.NotEqual(Guid.Empty, result.Value);

            _orderRepo.Verify(r => r.AddAsync(It.IsAny<Order>()), Times.Once);
        }
    }
}
