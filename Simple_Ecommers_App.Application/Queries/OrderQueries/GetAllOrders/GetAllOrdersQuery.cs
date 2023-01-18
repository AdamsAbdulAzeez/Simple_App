using MediatR;
using Simple_Ecommers_App.Application.Dtos;
using System.Collections.Generic;

namespace Simple_Ecommers_App.Application.Queries.OrderQueries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<OrderDto>> { }
}
