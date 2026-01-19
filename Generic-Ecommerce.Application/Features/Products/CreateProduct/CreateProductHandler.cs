using Generic_Ecommerce.Application.Exceptions;
using Generic_Ecommerce.Application.Interfaces.Repositories;
using Generic_Ecommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Ecommerce.Application.Features.Products.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Result<Guid>>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name))
                throw new BusinessException(AppErrorCatalog.CreateProductNameEmpty.Code, AppErrorCatalog.CreateProductNameEmpty.Message);

            if(request.Price < 0)
                throw new BusinessException(AppErrorCatalog.CreateProductPriceNegative.Code, AppErrorCatalog.CreateProductPriceNegative.Message);

            if (request.StockQuantity < 0)
                throw new BusinessException(AppErrorCatalog.CreateProductStockQuantityNegative.Code, AppErrorCatalog.CreateProductStockQuantityNegative.Message);

            var product = new Product(request.Name, request.Price, request.StockQuantity);
           
            await _productRepository.AddAsync(product);
            return Result<Guid>.Ok(product.Id);
        }
    }
}
