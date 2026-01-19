using Generic_Ecommerce.Application.Features.Products.CreateProduct;
using Generic_Ecommerce.Application.Features.Products.GetAllProducts;
using Generic_Ecommerce.Application.Features.Products.GetProductStockById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Generic_Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpGet("{id}/getStock")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(
                new GetProductStockByIdQuery(id));

            return Ok(result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll(Guid id)
        {
            var result = await _mediator.Send(
                new GetAllProductsQuery());

            return Ok(result);
        }
    }
}
