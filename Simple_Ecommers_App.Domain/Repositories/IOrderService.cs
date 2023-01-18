using System;
using System.Threading.Tasks;

namespace Simple_Ecommers_App.Domain.Repositories
{
    public interface IOrderService
    {
        Task<decimal> CalculateTotalAmount(Guid orderId);
    }
}
