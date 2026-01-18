using Generic_Ecommerce.Application.Exceptions;
using MediatR;

namespace Generic_Ecommerce.Application.Features.Orders.GetCustomerOrders
{
    public record GetCustomerOrdersQuery(Guid CustomerId)
        : IRequest<Result<List<CustomerOrderDto>>>;
}
