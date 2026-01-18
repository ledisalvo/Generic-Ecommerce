using Generic_Ecommerce.Application.Exceptions;
using Generic_Ecommerce.Application.Interfaces.Repositories;
using Generic_Ecommerce.Domain.Entities;
using MediatR;

namespace Generic_Ecommerce.Application.Features.Orders.CreateOrder
{
    public class CreateOrderHandler
    : IRequestHandler<CreateOrderCommand, Result<Guid>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderHandler(
            ICustomerRepository customerRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public async Task<Result<Guid>> Handle(
            CreateOrderCommand request,
            CancellationToken cancellationToken)
        {
            if (request.Items.Count == 0)
                return Result<Guid>.Fail(AppErrorCatalog.OrderOrderItemsEmpty.Code, AppErrorCatalog.OrderOrderItemsEmpty.Message);

            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            if (customer is null)
                return Result<Guid>.Fail(AppErrorCatalog.GetCustomerCustomerNotFound.Code, AppErrorCatalog.GetCustomerCustomerNotFound.Message);

            var order = new Order(request.CustomerId);

            foreach (var item in request.Items)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                if (product is null)
                    return Result<Guid>.Fail(AppErrorCatalog.ProductNotFound.Code, AppErrorCatalog.ProductNotFound.Message);

                var productStock = await _productRepository.GetByIdAsync(item.ProductId);
                if (productStock.StockQuantity == 0)
                    return Result<Guid>.Fail(AppErrorCatalog.ProductOutOfStock.Code, AppErrorCatalog.ProductOutOfStock.Message);

                product.DecreaseStock(item.Quantity);

                order.AddItem(
                    product.Id,
                    item.Quantity,
                    product.Price
                );
            }

            order.CalculateTotal();

            await _orderRepository.AddAsync(order);
            return Result<Guid>.Ok(order.Id);
        }
    }

}
