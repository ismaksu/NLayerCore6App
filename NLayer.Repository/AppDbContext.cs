using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Repository.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature()
            {
                Id = 1,
                Color = "Turkuaz",
                Height = 3,
                Width = 20,
                ProductId = 1
            },
            new ProductFeature()
            {
                Id = 2,
                Color = "Kırmızı",
                Height = 2,
                Width = 15,
                ProductId = 2
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
