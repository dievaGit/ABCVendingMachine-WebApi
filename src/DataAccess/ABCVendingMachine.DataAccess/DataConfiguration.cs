using ABCVendingMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABCVendingMachine.DataAccess
{
    public static class DataConfiguration
    {
        public static void AddData(ApplicationDBContext context)
        {
            var random = new Random();

            //Adding Products to DB
            for (int i = 1; i <= 5; i++)
            {
                context.Products.Add(new Product
                {
                    ProductName = $"Product{i}",
                    ProductCategoryId = random.Next(1, 5),
                    Price = random.Next(1, 10),
                    IsDeleted = 0
                });
            }
            
            //Adding ProductCategories to DB
            for (int i = 1; i <= 3; i++)
            {
                context.ProductsCategories.Add(new ProductCategory
                {
                    ProductCategoryName = $"Category{i}"
                });
            }

            //Adding VendingMachines to DB
            for (int i = 1; i <= 2; i++)
            {
                context.VendingMachines.Add(new VendingMachine
                {
                    VendingMachineName = $"Machine{i}",
                    Location = i
                }); 
            }

            //Adding ProductVendingMachines to DB
            for (int i = 1; i <= 2; i++)
            {
                var countItemsMachine = random.Next(2, 3);
                for (int j = 1; j <= countItemsMachine; j++)
                {
                    context.ProductVendingMachines.Add(new ProductVendingMachine
                    {
                           VendingMachineId = i,
                        ProductId = random.Next(1, 5),
                        Stock = random.Next(1, 5),
                        InventoryDay = DateTime.Now,
                        IsDeleted = 0
                    });
                }
                
            }

            //Adding Warehouses to DB
            for (int i = 1; i <= 2; i++)
            {                
                context.Warehouses.Add(new Warehouse
                {
                    WarehouseName = $"Warehouse{i}",
                    Location = i,

                });                
            }

            //Adding ProductWarehouses to DB
             for (int i = 1; i <= 2; i++)
            {
                var countProducts = random.Next(3, 4);
                for (int j = 1; j <= countProducts; j++)
                {
                    context.ProductWarehouses.Add(new ProductWarehouse
                    {
                        WarehouseId = i,
                        ProductId = random.Next(1, 2),
                        Stock = random.Next(5, 10),
                        InventoryDay = DateTime.Now,
                        IsDeleted = 0
                    });
                }
                
            }

            //Adding Trucks to DB
            for (int i = 1; i <= 2; i++)
            {
                context.Trucks.Add(new Truck
                {
                    TruckName = $"Truck {i}",
                    WarehouseId = i,
                });
            }

            //Adding OrderProductDetails to DB
            var count = random.Next(1, 2);
              for (int i = 1; i <= count; i++)
              {
                 context.OrderProductDetails.Add(new OrderProductDetail
                 {
                    ProductId = random.Next(1, 5),
                    OrderId = 1,
                    Quantity = random.Next(5, 10),
                    IsDeleted = 0
                 });
              }

            //Adding Orders to DB            
            context.Orders.Add(new Order
            {
                VendingMachineId = random.Next(1, 2),
                WarehouseId = random.Next(1, 2),
                CreatedAt = DateTime.Now,
                Items = context.OrderProductDetails.ToList(),
                IsDeleted = 0
            });

            //Adding User to DB
            context.Users.Add(new User
            {
                UserId = 1,
                UserName = "Jeff",
                Pass = "123",
                Role = "admin",
            });

            context.Users.Add(new User
            {
                UserId = 2,
                UserName = "Matt",
                Pass = "456",
                Role = "manager",
            });

            context.SaveChanges();
        }
    }
}
