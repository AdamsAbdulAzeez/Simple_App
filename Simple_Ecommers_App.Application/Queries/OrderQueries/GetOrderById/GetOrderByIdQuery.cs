using MediatR;
using Simple_Ecommers_App.Application.Dtos;
using System;

namespace Simple_Ecommers_App.Application.Queries.OrderQueries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public Guid Id { get; set; }
    }
}
