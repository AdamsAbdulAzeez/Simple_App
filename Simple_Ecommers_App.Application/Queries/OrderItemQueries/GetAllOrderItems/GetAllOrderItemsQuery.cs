using MediatR;
using Simple_Ecommers_App.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Ecommers_App.Application.Queries.OrderItemQueries.GetAllOrderItems
{
    public class GetAllOrderItemsQuery : IRequest<IEnumerable<OrderItemDto>>
    {
    }
}
