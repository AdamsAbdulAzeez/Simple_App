using Microsoft.EntityFrameworkCore;
using Simple_Ecommers_App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Ecommers_App.Infrastructure.Data
{
    public class SimpleEcommersAppDbContext : DbContext
    {
        private readonly DbContextOptions<SimpleEcommersAppDbContext> _options;

        public SimpleEcommersAppDbContext(DbContextOptions<SimpleEcommersAppDbContext> options) : base(options)
        {
            _options = options;
        }

        public DbSet<ProductEntity> ProductEntity { get; set; }
        public DbSet<CustomerEntity> CustomerEntity { get; set; }
        public DbSet<OrderEntity> OrderEntity { get; set; }
        public DbSet<OrderItemEntity> OrderItemEntity { get; set; }
    }
}
