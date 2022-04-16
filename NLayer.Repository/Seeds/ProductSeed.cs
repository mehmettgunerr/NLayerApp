﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
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
                new Product
                {
                    Id = 1,
                    CategoryId = 1,
                    Price = 100,
                    Stock = 20,
                    Name = "Lenovo",
                    CreatedDate = DateTime.Now
                },
                 new Product
                 {
                     Id = 2,
                     CategoryId = 1,
                     Price = 200,
                     Stock = 20,
                     Name = "MSI",
                     CreatedDate = DateTime.Now
                 },
                  new Product
                  {
                      Id = 3,
                      CategoryId = 1,
                      Price = 300,
                      Stock = 20,
                      Name = "MAC",
                      CreatedDate = DateTime.Now
                  },
                   new Product
                   {
                       Id = 4,
                       CategoryId = 2,
                       Price = 400,
                       Stock = 20,
                       Name = "IPHONE",
                       CreatedDate = DateTime.Now
                   },
                    new Product
                    {
                        Id = 5,
                        CategoryId = 3,
                        Price = 500,
                        Stock = 20,
                        Name = "KULAKLIK",
                        CreatedDate = DateTime.Now
                    }
                );
        }
    }
}
