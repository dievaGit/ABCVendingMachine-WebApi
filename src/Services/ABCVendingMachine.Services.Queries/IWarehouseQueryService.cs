using ABCVendingMachine.Services.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABCVendingMachine.Services.Queries
{
    public interface IWarehouseQueryService
    {
        Task<List<WarehouseDto>> GetAllWarehouses();
        Task<List<ProductWarehouseDto>> GetAllProductsWarehousesStock();
        Task<List<ProductWarehouseDto>> GetInventoryProductsWarehouse(int warehouseId);        
    }
}
