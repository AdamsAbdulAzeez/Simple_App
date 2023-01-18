using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Ecommers_App.Application.Dtos
{
    public class ProductDto : DtoBase
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
