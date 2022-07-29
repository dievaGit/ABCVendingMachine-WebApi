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
    public class VendingMachineController : ControllerBase
    {
        private readonly IVendingMachineQueryService _vendingMachineQueryService;
        private readonly ILogger<VendingMachineController> _logger;

        public VendingMachineController(IVendingMachineQueryService vendingMachineQueryService,
                                        ILogger<VendingMachineController> logger)
        {
            _vendingMachineQueryService = vendingMachineQueryService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<VendingMachineDto>>> GetAllVendingMachine()
        {
            var result = await _vendingMachineQueryService.GetAllVendingMachine();
            return await Task.FromResult(result);
        }

        [HttpGet]
        [Route("{vendingMachineId}")]
        public async Task<ActionResult<List<ProductVendingMachineDto>>> GetInventoryVendingMachine(int vendingMachineId)
        {
            var result = await _vendingMachineQueryService.GetInventoryVendingMachine(vendingMachineId);
            return await Task.FromResult(result);
        }
    }
}
