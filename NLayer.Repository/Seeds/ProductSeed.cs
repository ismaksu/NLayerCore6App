using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, CategoryId = 1, Name = "Faber Castell", Price = 100, Stock = 65, CreationDate = DateTime.Now },
                new Product { Id = 2, CategoryId = 1, Name = "Rotring", Price = 150, Stock = 55, CreationDate = DateTime.Now },
                new Product { Id = 3, CategoryId = 1, Name = "Studi", Price = 40, Stock = 100, CreationDate = DateTime.Now },
                new Product { Id = 4, CategoryId = 2, Name = "Dostoyevski", Price = 30, Stock = 25, CreationDate = DateTime.Now },
                new Product { Id = 5, CategoryId = 2, Name = "Ömer Seyfettin", Price = 25, Stock = 33, CreationDate = DateTime.Now },
                new Product { Id = 6, CategoryId = 3, Name = "Müzik Defteri", Price = 20, Stock = 40, CreationDate = DateTime.Now });
        }
    }
}
