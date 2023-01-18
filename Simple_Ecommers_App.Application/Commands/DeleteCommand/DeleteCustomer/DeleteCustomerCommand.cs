using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Ecommers_App.Application.Commands.DeleteCommand.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
