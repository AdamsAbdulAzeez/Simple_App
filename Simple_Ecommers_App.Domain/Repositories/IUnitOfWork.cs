using Simple_Ecommers_App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Ecommers_App.Domain.Repositories
{
    public interface IUnitOfWork
    {
         ICustomerRepository CustomerRepository { get; set; }
         IOrderItemRepository OrderItemRepository { get; set; }
         IOrderRepository OrderRepository { get; set; }
         IProductRepository ProductRepository { get; set; }
         Task<bool> CommitAsync();
    }
}
