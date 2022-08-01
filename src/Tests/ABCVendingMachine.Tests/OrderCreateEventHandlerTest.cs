using ABCVendingMachine.DataAccess;
using ABCVendingMachine.Models;
using ABCVendingMachine.Services.EventHandlers;
using ABCVendingMachine.Services.EventHandlers.Commands;
using ABCVendingMachine.Services.EventHandlers.Exceptions;
using ABCVendingMachine.Tests.DataConfig;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ABCVendingMachine.Tests
{
    [TestClass]
    public class OrderCreateEventHandlerTest
    {
        private ILogger<OrderCreateEventHandler> GetIlogger
        {
            get
            {
                return new Mock<ILogger<OrderCreateEventHandler>>().Object;
            }
        }

        [TestMethod]
        public async Task Trying_To_Add_New_Order_Should_Succeeded()
        {
            //Arrange
            var context = ApplicationDbContextInMemory.Get();

            context.ProductWarehouses.Add(new ProductWarehouse
            {
                WarehouseId = 1,
                ProductId = 1,
                Stock = 5,
                InventoryDay = DateTime.Now,
                IsDeleted = 0
            });

            //Act

            context.SaveChanges();

            var action = new OrderCreateEventHandler(context, GetIlogger);

            var result = await action.Handle(new OrderCreateCommand
            {
                OrderId = 1,
                VendingMachineId = 1,
                WarehouseId = 1,
                CreatedAt = DateTime.Now,
                Items = new List<DetailOrderProductComand>
                        {
                        new DetailOrderProductComand()
                        {
                            OrderProductDetailId = 1,
                            ProductId = 1,
                            OrderId = 10,
                            Quantity = 1,
                            ProductPrice = 3
                        }                
                }                    
            }, new CancellationToken());

            //Assert

            Assert.IsTrue(result);
        }    
    }
}
