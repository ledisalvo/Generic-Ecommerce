using Generic_Ecommerce.Application.Exceptions;
using Generic_Ecommerce.Application.Interfaces.Repositories;
using MediatR;

namespace Generic_Ecommerce.Application.Features.Products.GetProductStockById
{
    public class GetProductStockByIdHandler : IRequestHandler<GetProductStockByIdQuery, Result<int>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductStockByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<int>> Handle(GetProductStockByIdQuery request, CancellationToken cancellationToken)
        {
            var productStock = await _productRepository.GetStockByIdAsync(request.ProductId);
            if (productStock == 0)
                return Result<int>.Fail(AppErrorCatalog.ProductOutOfStock.Code, AppErrorCatalog.ProductOutOfStock.Message);

            return Result<int>.Ok(productStock);
        }
    }
}
