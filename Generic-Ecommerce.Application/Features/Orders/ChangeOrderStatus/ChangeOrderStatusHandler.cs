using Generic_Ecommerce.Application.Exceptions;
using Generic_Ecommerce.Application.Interfaces.Repositories;
using MediatR;

namespace Generic_Ecommerce.Application.Features.Orders.ChangeOrderStatus
{
    public class ChangeOrderStatusHandler
    : IRequestHandler<ChangeOrderStatusCommand, Result<bool>>
    {
        private readonly IOrderRepository _orderRepository;

        public ChangeOrderStatusHandler(IOrderRepository orderRepo)
        {
            _orderRepository = orderRepo;
        }

        public async Task<Result<bool>> Handle(
            ChangeOrderStatusCommand request,
            CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId);

            if (order is null)
                throw new NotFoundException(AppErrorCatalog.OrderNotFound.Code, AppErrorCatalog.OrderNotFound.Message);

            order.ChangeStatus(request.NewStatus);
            await _orderRepository.UpdateAsync(order);

            return Result<bool>.Ok(true);
        }
    }

}
