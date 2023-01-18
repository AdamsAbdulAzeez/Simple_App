using Simple_Ecommers_App.Domain.Repositories;
using Simple_Ecommers_App.Infrastructure.Data;
using System.Threading.Tasks;

namespace Simple_Ecommers_App.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SimpleEcommersAppDbContext _context;

        public UnitOfWork(SimpleEcommersAppDbContext context)
        {
            _context = context;
            CustomerRepository = new CustomerRepository(context);
            OrderItemRepository = new OrderItemRepository(context);
            OrderRepository = new OrderRepository(context);
            ProductRepository = new ProductRepository(context);
        }
        public ICustomerRepository CustomerRepository { get; set; }
        public IOrderItemRepository OrderItemRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }

        public async Task<bool> CommitAsync()
        {
            var status = await _context.SaveChangesAsync();
            if (status > 0) 
            {
                return true;
            }
            return false;
        }
    }
}
