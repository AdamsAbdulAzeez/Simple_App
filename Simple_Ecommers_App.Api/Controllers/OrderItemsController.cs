using MediatR;
using Microsoft.AspNetCore.Mvc;
using Simple_Ecommers_App.Application.Commands.CreateCommand.CreateOrderItem;
using Simple_Ecommers_App.Application.Commands.DeleteCommand.DeleteOrderItem;
using Simple_Ecommers_App.Application.Commands.UpdateCommand.UpdateOrderItem;
using Simple_Ecommers_App.Application.Dtos;
using Simple_Ecommers_App.Application.Queries.OrderItemQueries.GetAllOrderItems;
using Simple_Ecommers_App.Application.Queries.OrderItemQueries.GetOrderItemById;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simple_Ecommers_App.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItemDto>>> GetAllOrderItems()
        {
            var query = new GetAllOrderItemsQuery();
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemDto>> GetOrderItemById(Guid id)
        {
            var query = new GetOrderItemByIdQuery { Id = id };
            var product = await _mediator.Send(query);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderItem([FromBody] CreateOrderItemCommand command)
        {
            var productId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetOrderItemById), new { id = productId }, null);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderItem([FromBody] UpdateOrderItemCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(Guid id)
        {
            var query = new DeleteOrderItemCommand { Id = id };
            await _mediator.Send(query);
            return NoContent();
        }
    }
}
