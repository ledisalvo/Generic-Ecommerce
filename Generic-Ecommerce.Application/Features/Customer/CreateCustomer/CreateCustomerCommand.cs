using Generic_Ecommerce.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Ecommerce.Application.Features.Customer.CreateCustomer
{
    public record CreateCustomerCommand(
        Guid Id,
        string Name,
        string Email,
        string? PhoneNumber
        ) : IRequest<Result<Guid>>;
}
