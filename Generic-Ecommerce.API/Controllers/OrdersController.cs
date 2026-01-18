using Generic_Ecommerce.Application.Features.Orders.ChangeOrderStatus;
using Generic_Ecommerce.Application.Features.Orders.CreateOrder;
using Generic_Ecommerce.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Generic_Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> ChangeStatus(
            Guid id,
            [FromBody] OrderStatus status)
        {
            await _mediator.Send(new ChangeOrderStatusCommand(id, status));
            return NoContent();
        }

        // opcional para completar REST
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(); // se puede implementar después
        }
    }

}
