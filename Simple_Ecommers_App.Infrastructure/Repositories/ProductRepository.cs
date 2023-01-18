using Simple_Ecommers_App.Domain.Entities;
using Simple_Ecommers_App.Domain.Repositories;
using Simple_Ecommers_App.Infrastructure.Data;

namespace Simple_Ecommers_App.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(SimpleEcommersAppDbContext context) : base(context)
        {
        }
    }
}
