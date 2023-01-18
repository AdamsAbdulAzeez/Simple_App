using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Ecommers_App.Application.Dtos
{
    public class OrderItemDto : DtoBase
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
