using Generic_Ecommerce.Application.Exceptions;
using MediatR;

namespace Generic_Ecommerce.Application.Features.Customer.GetCustomerById
{
    public record GetCustomerByIdQuery(Guid CustomerId)
        : IRequest<Result<CustomerDetailDto>>;

}
