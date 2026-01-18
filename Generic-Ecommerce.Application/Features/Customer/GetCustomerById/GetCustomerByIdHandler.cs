using System.Linq;
using Generic_Ecommerce.Application.Exceptions;
using Generic_Ecommerce.Application.Features.Orders.GetCustomerOrders;
using Generic_Ecommerce.Application.Interfaces.Repositories;
using MediatR;

namespace Generic_Ecommerce.Application.Features.Customer.GetCustomerById
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Result<CustomerDetailDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;

        public GetCustomerByIdHandler(
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        public async Task<Result<CustomerDetailDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            if (customer is null)
                return Result<CustomerDetailDto>.Fail(AppErrorCatalog.GetCustomerCustomerNotFound.Code, AppErrorCatalog.GetCustomerCustomerNotFound.Message);

            var orders = await _orderRepository.GetByCustomerIdAsync(customer.Id);

            return Result<CustomerDetailDto>.Ok(new CustomerDetailDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Orders = orders.Select(o => new CustomerOrderDto
                {
                    OrderId = o.Id,
                    CreatedAt = o.CreatedAt,
                    Status = o.Status,
                    TotalAmount = o.TotalAmount
                }).ToList()
            });
        }
    }
}
