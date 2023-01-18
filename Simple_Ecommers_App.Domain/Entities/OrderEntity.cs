using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Ecommers_App.Domain.Entities
{
    public class OrderEntity : EntityBase
    {
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public List<OrderItemEntity> Items { get; set; }
    }
}
