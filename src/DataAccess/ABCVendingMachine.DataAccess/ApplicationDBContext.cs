using ABCVendingMachine.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ABCVendingMachine.DataAccess
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(
           DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductsCategories { get; set; }
        public DbSet<ProductVendingMachine> ProductVendingMachines { get; set; }
        public DbSet<ProductWarehouse> ProductWarehouses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProductDetail> OrderProductDetails { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<VendingMachine> VendingMachines { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<User> Users { get; set; }

    }

}
