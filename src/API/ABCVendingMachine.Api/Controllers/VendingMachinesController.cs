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
    public class VendingMachinesController : ControllerBase
    {
        private readonly IVendingMachinesQueryService _vendingMachineQueryService;
        private readonly ILogger<VendingMachinesController> _logger;

        public VendingMachinesController(IVendingMachinesQueryService vendingMachineQueryService,
                                        ILogger<VendingMachinesController> logger)
        {
            _vendingMachineQueryService = vendingMachineQueryService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<VendingMachineDto>>> GetAllVendingMachinesAsync()
        {
            var result = await _vendingMachineQueryService.GetAllVendingMachinesAsync();
            return await Task.FromResult(result);
        }

        [HttpGet]
        [Route("{vendingMachineId}")]
        public async Task<ActionResult<List<ProductVendingMachineDto>>> GetAllProductsByVendingMachineIdAsync(int vendingMachineId)
        {
            var result = await _vendingMachineQueryService.GetAllProductsByVendingMachineIdAsync(vendingMachineId);
            return await Task.FromResult(result);
        }
    }
}
