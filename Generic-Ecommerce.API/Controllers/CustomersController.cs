using Generic_Ecommerce.Application.Features.Customer.CreateCustomer;
using Generic_Ecommerce.Application.Features.Customer.GetAllCustomers;
using Generic_Ecommerce.Application.Features.Customer.GetCustomerById;
using Generic_Ecommerce.Application.Features.Orders.GetCustomerOrders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Generic_Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(
                new GetCustomerByIdQuery(id));

            return Ok(result);
        }

        [HttpGet("{id}/orders")]
        public async Task<IActionResult> GetOrders(Guid id)
        {
            var result = await _mediator.Send(
                new GetCustomerOrdersQuery(id));

            return Ok(result);
        }

        [HttpGet("/getAll")]
        public async Task<IActionResult> GetAll(Guid id)
        {
            var result = await _mediator.Send(
                new GetAllCustomersQuery());

            return Ok(result);
        }
    }
}
