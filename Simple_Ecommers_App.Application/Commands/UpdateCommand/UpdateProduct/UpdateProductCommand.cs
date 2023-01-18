using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Ecommers_App.Application.Commands.UpdateCommand.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
