using ABCVendingMachine.DataAccess;
using ABCVendingMachine.Models;
using ABCVendingMachine.Services.EventHandlers.Commands;
using MediatR;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using ABCVendingMachine.Services.EventHandlers.Exceptions;

namespace ABCVendingMachine.Services.EventHandlers
{
    public class OrderCreateEventHandler : IRequestHandler<OrderCreateCommand, bool>
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<OrderCreateEventHandler> _logger;

        public OrderCreateEventHandler(ApplicationDBContext context, ILogger<OrderCreateEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> Handle(OrderCreateCommand message, CancellationToken cancellationToken)
        {
            var result = false;
            decimal orderTotalPrice = 0;

            try
            {
                _logger.LogInformation("New order creation started");
                _logger.LogInformation("Creating new order");
                var order = new Order
                {
                    VendingMachineId = message.VendingMachineId,
                    WarehouseId = message.WarehouseId,
                    CreatedAt = DateTime.Now,
                    IsDeleted = 0,
                };
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Preparing items ietails");
                foreach (var item in message.Items)
                {
                    var stock = (from pw in _context.ProductWarehouses
                                        where pw.WarehouseId == message.WarehouseId &&
                                        pw.ProductId == item.ProductId &&
                                        pw.Stock >= item.Quantity &&
                                        pw.IsDeleted == 0
                                        select pw).FirstOrDefault();

                    if (stock != null)
                    {
                        await _context.OrderProductDetails.AddAsync(new OrderProductDetail
                        {
                            ProductId = item.ProductId,
                            OrderId = order.OrderId,
                            Quantity = item.Quantity,
                            TotalPrice = item.Quantity * item.ProductPrice,
                            IsDeleted = 0,
                        });

                        orderTotalPrice += item.Quantity * item.ProductPrice;

                        //Updating Inventory
                        stock.Stock = stock.Stock - item.Quantity;
                        if(stock.Stock == 0)
                            stock.IsDeleted = 1; 

                        _context.ProductWarehouses.Update(stock);
                    }
                    else
                    {
                        _logger.LogInformation($"Not product in stock in Warehouse {message.WarehouseId}");
                        _context.Orders.Remove(order);
                        throw new OutOfStockException($"Product {stock.ProductId} - doens't have enough stock");

                    }            

                }

                order.TotalPrice = orderTotalPrice;
                _context.Orders.Update(order);

                await _context.SaveChangesAsync();

                result = true;
            }
            catch(Exception ex)
            {
                _logger.LogInformation($"Exception {ex} occur");
                throw ex;
            }

            return await Task.FromResult(result);
        }
    }
}
