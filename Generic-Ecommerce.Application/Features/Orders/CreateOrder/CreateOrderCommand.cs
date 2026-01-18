using Generic_Ecommerce.Application.Exceptions;
using MediatR;

namespace Generic_Ecommerce.Application.Features.Orders.CreateOrder
{
    public record CreateOrderCommand(
    Guid CustomerId,
    List<CreateOrderItemDto> Items
) : IRequest<Result<Guid>>;

}
