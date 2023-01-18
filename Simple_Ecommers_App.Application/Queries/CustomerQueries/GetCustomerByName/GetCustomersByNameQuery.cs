using MediatR;
using Simple_Ecommers_App.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Ecommers_App.Application.Queries.CustomerQueries.GetCustomerByName
{
    public class GetCustomersByNameQuery : IRequest<IEnumerable<CustomerDto>>
    {
        public string Name { get; set; }
    }
}
