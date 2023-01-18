using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Ecommers_App.Application.Commands.CreateCommand.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
