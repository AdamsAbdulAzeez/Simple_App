using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Ecommers_App.Application.Dtos
{
    public class OrderDto : DtoBase
    {
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
}
