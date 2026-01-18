using Generic_Ecommerce.Application.Exceptions;
using Generic_Ecommerce.Domain.Enums;
using MediatR;

namespace Generic_Ecommerce.Application.Features.Orders.ChangeOrderStatus
{
    public record ChangeOrderStatusCommand(
        Guid OrderId,
        OrderStatus NewStatus
    ) : IRequest<Result<bool>>;

}
