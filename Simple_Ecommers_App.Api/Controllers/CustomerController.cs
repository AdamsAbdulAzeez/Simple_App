using MediatR;
using Microsoft.AspNetCore.Mvc;
using Simple_Ecommers_App.Application.Commands.CreateCommand.CreateCustomer;
using Simple_Ecommers_App.Application.Commands.DeleteCommand.DeleteCustomer;
using Simple_Ecommers_App.Application.Commands.UpdateCommand.UpdateCustomer;
using Simple_Ecommers_App.Application.Dtos;
using Simple_Ecommers_App.Application.Queries.CustomerQueries.GetAllCustomers;
using Simple_Ecommers_App.Application.Queries.CustomerQueries.GetCustomerById;
using Simple_Ecommers_App.Application.Queries.CustomerQueries.GetCustomerByName;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simple_Ecommers_App.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomer()
        {
            var query = new GetAllCustomersQuery();
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(Guid id)
        {
            var query = new GetCustomerByIdQuery { Id = id };
            var product = await _mediator.Send(query);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            var productId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCustomerById), new { id = productId }, null);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderItem([FromBody] UpdateCustomerCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(Guid id)
        {
            var query = new DeleteCustomerCommand { Id = id };
            await _mediator.Send(query);
            return NoContent();
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetByName(string name)
        {
            var query = new GetCustomersByNameQuery { Name = name };
            var customers = await _mediator.Send(query);
            return Ok(customers);
        }
    }
}
