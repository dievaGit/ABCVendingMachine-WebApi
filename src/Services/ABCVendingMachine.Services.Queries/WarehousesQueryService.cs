using ABCVendingMachine.DataAccess;
using ABCVendingMachine.Services.Queries.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ABCVendingMachine.Services.Queries
{
    public class WarehousesQueryService : IWarehousesQueryService
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<WarehousesQueryService> _logger;

        public WarehousesQueryService(ApplicationDBContext context, ILogger<WarehousesQueryService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<WarehouseDto>> GetAllWarehousesAsync()
        {
            var result = (from w in _context.Warehouses
                          select new WarehouseDto
                          {
                              WarehouseId = w.WarehouseId,
                              WarehouseName = w.WarehouseName,
                              Location = w.Location,
                          }).ToList();

            return await Task.FromResult(result);
        }

        public async Task<List<ProductWarehouseDto>> GetAllProductsFromAllWarehousesAsync()
        {

            var result = (from pw in _context.ProductWarehouses
                          join p in _context.Products on pw.ProductId equals p.ProductId
                          where pw.IsDeleted == 0 && p.IsDeleted == 0
                          select new ProductWarehouseDto
                          {
                              ProductWarehouseId = pw.ProductWarehouseId,
                              WarehouseId = pw.WarehouseId,
                              ProductId = p.ProductId,
                              ProductCategoryId = p.ProductCategoryId,
                              ProductName = p.ProductName,
                              Price = p.Price,
                              Stock = pw.Stock,
                          }).ToList();

            return await Task.FromResult(result);
        }

        public async Task<List<ProductWarehouseDto>> GetAllProductsByWarehouseIdAsync(int warehouseId)
        {
            var result = (from pw in _context.ProductWarehouses
                          join p in _context.Products on pw.ProductId equals p.ProductId
                          where pw.WarehouseId == warehouseId && pw.IsDeleted == 0 && p.IsDeleted == 0
                          select new ProductWarehouseDto
                          {
                              ProductWarehouseId = pw.ProductWarehouseId,
                              WarehouseId = pw.WarehouseId,
                              ProductId = p.ProductId,
                              ProductCategoryId = p.ProductCategoryId,
                              ProductName = p.ProductName,
                              Price = p.Price,
                              Stock = pw.Stock,
                          }).ToList();

            return await Task.FromResult(result);
        }
    }
}
