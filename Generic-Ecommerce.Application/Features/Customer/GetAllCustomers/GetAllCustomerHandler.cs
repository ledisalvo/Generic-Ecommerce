using Generic_Ecommerce.Application.Exceptions;
using Generic_Ecommerce.Application.Features.Customer.GetCustomerById;
using Generic_Ecommerce.Application.Features.Orders.GetCustomerOrders;
using Generic_Ecommerce.Application.Interfaces.Repositories;
using MediatR;

namespace Generic_Ecommerce.Application.Features.Customer.GetAllCustomers
{
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, Result<List<CustomerDto>>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;

        public GetAllCustomersHandler(
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        public async Task<Result<List<CustomerDto>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _customerRepository.GetAll();

            return Result<List<CustomerDto>>.Ok(orders.Select(x => new CustomerDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email
            }).ToList());
        }
    }
}
