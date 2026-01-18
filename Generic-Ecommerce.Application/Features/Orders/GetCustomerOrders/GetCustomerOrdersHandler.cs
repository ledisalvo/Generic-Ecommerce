using Generic_Ecommerce.Application.Exceptions;
using Generic_Ecommerce.Application.Interfaces.Repositories;
using MediatR;

namespace Generic_Ecommerce.Application.Features.Orders.GetCustomerOrders
{
    public class GetCustomerOrdersHandler
    : IRequestHandler<GetCustomerOrdersQuery, Result<List<CustomerOrderDto>>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetCustomerOrdersHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<List<CustomerOrderDto>>> Handle(
            GetCustomerOrdersQuery request,
            CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetByCustomerIdAsync(request.CustomerId);

            if (orders is null)
                return Result<List<CustomerOrderDto>>.Fail(AppErrorCatalog.GetCustomerOrderEmpty.Code, AppErrorCatalog.GetCustomerOrderEmpty.Message);

            return Result<List<CustomerOrderDto>>.Ok(orders.Select(o => new CustomerOrderDto
            {
                OrderId = o.Id,
                CreatedAt = o.CreatedAt,
                Status = o.Status,
                TotalAmount = o.TotalAmount,
                Items = o.OrderItems.Select(i => new CustomerOrderItemDto
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList()
            }).ToList());
        }
    }

}
