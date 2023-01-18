using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Ecommers_App.Domain.Entities
{
    public class CustomerEntity : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
