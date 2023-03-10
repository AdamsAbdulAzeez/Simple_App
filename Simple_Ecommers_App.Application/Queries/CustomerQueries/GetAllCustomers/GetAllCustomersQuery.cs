using MediatR;
using Simple_Ecommers_App.Application.Dtos;
using System.Collections.Generic;

namespace Simple_Ecommers_App.Application.Queries.CustomerQueries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<CustomerDto>> { }
}
