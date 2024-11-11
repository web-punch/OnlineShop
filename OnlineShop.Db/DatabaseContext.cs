using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new List<Product>()
                {
                    new Product() 
                    {
                        Id = Guid.NewGuid(),
                        Name = "Розы",
                        Cost = 400,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.",
                        ImagesPaths = new List<string>
                        {
                            "/images/roses.jpg",
                        },
                        ActiveIndexImagePath = 0,
                    },
                    new Product()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Хризантемы",
                        Cost=300,
                        Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.",
                        ImagesPaths = new List<string>
                        {
                            "/images/chrysanthemums.jpg",
                        },
                        ActiveIndexImagePath = 0,
                    },
                    new Product()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Гвоздики",
                        Cost = 250,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.",
                        ImagesPaths = new List<string>
                        {
                            "/images/carnations.jpg",
                        },
                        ActiveIndexImagePath = 0,
                    },
                    new Product()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Пионы",
                        Cost = 200,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.",
                        ImagesPaths = new List<string>
                        {
                            "/images/peonies.jpg",
                        },
                        ActiveIndexImagePath = 0,
                    },
                    new Product()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Ромашки",
                        Cost = 150,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.",
                        ImagesPaths = new List<string>
                        {
                            "/images/chamomiles.jpg",
                        },
                        ActiveIndexImagePath = 0,
                    },
                    new Product()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Тюльпаны",
                        Cost = 200,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.",
                        ImagesPaths = new List <string>
                        {
                            "/images/tulips.jpg",
                        },
                        ActiveIndexImagePath = 0
                    }
                }
            );
        }
    }
}
