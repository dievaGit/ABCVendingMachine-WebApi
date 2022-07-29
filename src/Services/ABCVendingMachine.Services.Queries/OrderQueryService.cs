using ABCVendingMachine.DataAccess;
using ABCVendingMachine.Services.Queries.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ABCVendingMachine.Services.Queries
{
    public class OrderQueryService : IOrderQueryService
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<OrderQueryService> _logger;

        public OrderQueryService(ApplicationDBContext context, ILogger<OrderQueryService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<List<OrderDto>> GetAllOrder()
        {
            var result = (from o in _context.Orders
                          where o.IsDeleted == 0
                          select new OrderDto
                          {
                              OrderId = o.OrderId,
                              VendingMachineId = o.VendingMachineId,
                              WarehouseId = o.WarehouseId,
                              Items = (from od in _context.OrderProductDetails
                                       join p in _context.Products on od.ProductId equals p.ProductId
                                       where od.OrderId == o.OrderId && od.IsDeleted == 0
                                       select new OrderProductDetailDto
                                       {
                                           OrderProductDetailId = od.OrderProductDetailId,
                                           ProductId = od.ProductId,
                                           Quantity = od.Quantity,
                                           TotalPrice = p.Price * od.Quantity
                                       })
                          }).ToList();
           
            return await Task.FromResult(result);

        }
    }
}
