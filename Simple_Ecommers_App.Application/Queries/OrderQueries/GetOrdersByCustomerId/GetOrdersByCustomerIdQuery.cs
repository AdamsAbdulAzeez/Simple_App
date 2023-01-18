using MediatR;
using Simple_Ecommers_App.Application.Dtos;
using System;
using System.Collections.Generic;

namespace Simple_Ecommers_App.Application.Queries.OrderQueries.GetOrdersByCustomerId
{
    public class GetOrdersByCustomerIdQuery : IRequest<IEnumerable<OrderDto>>
    {
        public Guid CustomerId { get; set; }
    }
}
