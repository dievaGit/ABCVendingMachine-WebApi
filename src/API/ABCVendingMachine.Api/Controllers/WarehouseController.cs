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
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseQueryService _warehouseQueryService;
        private readonly ILogger<WarehouseController> _logger;

        public WarehouseController(IWarehouseQueryService warehouseQueryService, ILogger<WarehouseController> logger)
        {
            _warehouseQueryService = warehouseQueryService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<WarehouseDto>>> GetAllWarehouse()
        {
            var result = await _warehouseQueryService.GetAllWarehouse();
            return await Task.FromResult(result);
        }

        [HttpGet]
        [Route("products")]
        public async Task<ActionResult<List<ProductWarehouseDto>>> GetAllProductsWarehousesStock()
        {
            var result = await _warehouseQueryService.GetAllProductsWarehousesStock();
            return await Task.FromResult(result);
        }

        [HttpGet]
        [Route("{warehouseId}")]
        public async Task<ActionResult<List<ProductWarehouseDto>>> GetInventoryProductsWarehouse(int warehouseId)
        {
            var result = await _warehouseQueryService.GetInventoryProductsWarehouse(warehouseId);
            return await Task.FromResult(result);
        }

    }
}
