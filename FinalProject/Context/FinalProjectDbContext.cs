using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Models;

namespace FinalProject.Context
{
    public class FinalProjectDbContext : DbContext
    {
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<ProductReceive> ProductReceives { get; set; }

        public FinalProjectDbContext() : base("connectionString")
        {
        }

    }
}
