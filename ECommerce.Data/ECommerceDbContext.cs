using ECommerce.Model.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data
{
    public class ECommerceDbContext:DbContext
    {
        public ECommerceDbContext(string connectionString) : base(GetOptions(connectionString))
        {

        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

       


    }
}
