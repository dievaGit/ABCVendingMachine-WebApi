using ABCVendingMachine.Services.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABCVendingMachine.Services.Queries
{
    public interface IWarehousesQueryService
    {
        Task<List<WarehouseDto>> GetAllWarehousesAsync();
        Task<List<ProductWarehouseDto>> GetAllProductsFromAllWarehousesAsync();
        Task<List<ProductWarehouseDto>> GetAllProductsByWarehouseIdAsync(int warehouseId);        
    }
}
