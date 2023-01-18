using MediatR;
using Microsoft.AspNetCore.Mvc;
using Simple_Ecommers_App.Application.Commands.CreateCommand.CreateOrder;
using Simple_Ecommers_App.Application.Commands.DeleteCommand.DeleteOrder;
using Simple_Ecommers_App.Application.Commands.UpdateCommand.UpdateOrder;
using Simple_Ecommers_App.Application.Dtos;
using Simple_Ecommers_App.Application.Queries.OrderQueries.GetAllOrders;
using Simple_Ecommers_App.Application.Queries.OrderQueries.GetOrderById;
using Simple_Ecommers_App.Application.Queries.OrderQueries.GetOrdersByCustomerId;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simple_Ecommers_App.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrders()
        {
            var query = new GetAllOrdersQuery();
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrderById(Guid id)
        {
            var query = new GetOrderByIdQuery { Id = id };
            var product = await _mediator.Send(query);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var productId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetOrderById), new { id = productId }, null);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var query = new DeleteOrderCommand { Id = id };
            await _mediator.Send(query);
            return NoContent();
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetByCustomerId(Guid customerId)
        {
            var query = new GetOrdersByCustomerIdQuery { CustomerId = customerId };
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }
    }
}
