using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Ecommers_App.Application.Commands.DeleteCommand.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
