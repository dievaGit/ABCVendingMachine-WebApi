using ABCVendingMachine.Services.Queries;
using ABCVendingMachine.Services.Queries.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABCVendingMachine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehousesQueryService _warehouseQueryService;
        private readonly ILogger<WarehousesController> _logger;

        public WarehousesController(IWarehousesQueryService warehouseQueryService, ILogger<WarehousesController> logger)
        {
            _warehouseQueryService = warehouseQueryService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<WarehouseDto>>> GetAllWarehousesAsync()
        {
            var result = await _warehouseQueryService.GetAllWarehousesAsync();
            return await Task.FromResult(result);
        }

        [HttpGet]
        [Route("products")]
        public async Task<ActionResult<List<ProductWarehouseDto>>> GetAllProductsFromAllWarehousesAsync()
        {
            var result = await _warehouseQueryService.GetAllProductsFromAllWarehousesAsync();
            return await Task.FromResult(result);
        }

        [HttpGet]
        [Route("{warehouseId}")]
        public async Task<ActionResult<ProductWarehouseDto>> GetWarehouseByIdAsync(int warehouseId)
        {
            //var result = await _warehouseQueryService.GetInventoryProductsWarehouse(warehouseId);
            return await Task.FromResult(new ProductWarehouseDto());
        }

        [HttpGet]
        [Route("{warehouseId}/products")]
        public async Task<ActionResult<List<ProductWarehouseDto>>> GetAllProductsByWarehouseIdAsync(int warehouseId)
        {
            var result = await _warehouseQueryService.GetAllProductsByWarehouseIdAsync(warehouseId);
            return await Task.FromResult(result);
        }
    }
}
