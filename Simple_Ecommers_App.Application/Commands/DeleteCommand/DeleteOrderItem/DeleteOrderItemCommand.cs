using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Ecommers_App.Application.Commands.DeleteCommand.DeleteOrderItem
{
    public class DeleteOrderItemCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
