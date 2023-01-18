using MediatR;
using Simple_Ecommers_App.Application.Dtos;
using System;

namespace Simple_Ecommers_App.Application.Queries.CustomerQueries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<CustomerDto>
    {
        public Guid Id { get; set; }
    }
}
