using Generic_Ecommerce.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Ecommerce.Application.Features.Products.CreateProduct
{
    public record CreateProductCommand(
        string Name,
        decimal Price,
        int StockQuantity) : IRequest<Result<Guid>>;
}
