using Generic_Ecommerce.Application.Exceptions;
using MediatR;

namespace Generic_Ecommerce.Application.Features.Customer.GetAllCustomers
{
    public record GetAllCustomersQuery()
        : IRequest<Result<List<CustomerDto>>>;
}
