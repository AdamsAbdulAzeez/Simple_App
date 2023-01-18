using MediatR;
using Microsoft.AspNetCore.Mvc;
using Simple_Ecommers_App.Application.Commands.CreateCommand.CreateProduct;
using Simple_Ecommers_App.Application.Commands.DeleteCommand.DeleteProduct;
using Simple_Ecommers_App.Application.Commands.UpdateCommand.UpdateProduct;
using Simple_Ecommers_App.Application.Dtos;
using Simple_Ecommers_App.Application.Queries.ProductQueries.GetAllProducts;
using Simple_Ecommers_App.Application.Queries.ProductQueries.GetProductById;
using Simple_Ecommers_App.Application.Queries.ProductQueries.SearchProduct;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simple_Ecommers_App.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(Guid id)
        {
            var query = new GetProductByIdQuery { Id = id };
            var product = await _mediator.Send(query);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var productId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProductById), new { id = productId }, null);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var query = new DeleteProductCommand { Id = id };
            await _mediator.Send(query);
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Search([FromQuery] string name)
        {
            var products = await _mediator.Send(new SearchProductsQuery(name));
            return Ok(products);
        }
    }
}
