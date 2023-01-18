using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Ecommers_App.Domain.Entities
{
    public class ProductEntity : EntityBase
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
