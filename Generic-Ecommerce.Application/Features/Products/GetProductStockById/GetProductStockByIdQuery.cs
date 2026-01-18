using Generic_Ecommerce.Application.Exceptions;
using Generic_Ecommerce.Application.Features.Customer.GetCustomerById;
using MediatR;

namespace Generic_Ecommerce.Application.Features.Products.GetProductStockById
{
    public record GetProductStockByIdQuery(Guid ProductId)
        : IRequest<Result<int>>;
}
