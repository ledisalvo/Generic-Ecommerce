using Generic_Ecommerce.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Ecommerce.Application.Features.Products.GetAllProducts
{
    public record GetAllProductsQuery()
        : IRequest<Result<List<ProductDto>>>;
}
