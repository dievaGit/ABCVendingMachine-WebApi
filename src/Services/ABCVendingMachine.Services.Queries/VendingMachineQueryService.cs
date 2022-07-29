﻿using ABCVendingMachine.DataAccess;
using ABCVendingMachine.Services.Queries.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ABCVendingMachine.Services.Queries
{
    public class VendingMachineQueryService : IVendingMachineQueryService
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<VendingMachineQueryService> _logger;

        public VendingMachineQueryService(ApplicationDBContext context, ILogger<VendingMachineQueryService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<List<VendingMachineDto>> GetAllVendingMachine()
        {
            var result = (from vm in _context.VendingMachines
                          select new VendingMachineDto
                          {
                              VendingMachineId = vm.VendingMachineId,
                              VendingMachineName = vm.VendingMachineName,
                              Location = vm.Location,
                          }).ToList();

            return await Task.FromResult(result);
        }

        public async Task<List<ProductVendingMachineDto>> GetInventoryVendingMachine(int vendingMachineId)
        {
            var result = (from pvm in _context.ProductVendingMachines
                          join p in _context.Products on pvm.ProductId equals p.ProductId
                          where pvm.VendingMachineId == vendingMachineId && pvm.IsDeleted == 0 && p.IsDeleted == 0
                          select new ProductVendingMachineDto
                          {
                              ProductVendingMachineId = pvm.ProductVendingMachineId,
                              VendingMachineId = pvm.VendingMachineId,
                              ProductId = p.ProductId,
                              ProductCategoryId = p.ProductCategoryId,
                              ProductName = p.ProductName,
                              Price = p.Price,
                              Stock = pvm.Stock,
                          }).ToList();

            return await Task.FromResult(result);
        }
    }
}
