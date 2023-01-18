using MediatR;
using Simple_Ecommers_App.Application.Dtos;
using System;

namespace Simple_Ecommers_App.Application.Queries.ProductQueries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public Guid Id { get; set; }
    }
}
