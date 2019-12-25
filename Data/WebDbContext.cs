using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class WebDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public WebDbContext() : base("name=DbConnection")
        {

        }

        static WebDbContext()
        {
            Database.SetInitializer(new DbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(p => p.Products)
                .WithMany(p => p.Orders);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class DbInitializer : CreateDatabaseIfNotExists<WebDbContext>
    {
        protected override void Seed(WebDbContext context)
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 0,
                    Name = "One man",
                    Price = 1000M,
                },
                new Product
                {
                    Id = 1,
                    Name = "One soul",
                    Price = 1100M,
                },
                new Product
                {
                    Id = 2,
                    Name = "One heart",
                    Price = 900M,
                },
                new Product
                {
                    Id = 3,
                    Name = "One mission",
                    Price = 1300M,
                },
            };

            var orders = new List<Order>
            {
                new Order
                {
                    Id = 0,
                    Products = new List<Product>()
                    {
                        products[0],
                        products[2],
                    }
                },
                new Order
                {
                    Id = 1,
                    Products = new List<Product>()
                    {
                        products[0],
                        products[1],
                        products[2],
                        products[3],
                    }
                },
            };
            context.Orders.AddRange(orders);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
