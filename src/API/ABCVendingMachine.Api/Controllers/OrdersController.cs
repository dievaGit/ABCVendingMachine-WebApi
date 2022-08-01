using ABCVendingMachine.Services.EventHandlers.Commands;
using ABCVendingMachine.Services.Queries;
using ABCVendingMachine.Services.Queries.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABCVendingMachine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrdersQueryService _orderQueryService;

        public OrdersController(IMediator mediator, ILogger<OrdersController> logger, IOrdersQueryService orderQueryService)
        {
            _mediator = mediator;
            _logger = logger;
            _orderQueryService = orderQueryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetAllOrdersAsync()
        {
            var result = await _orderQueryService.GetAllOrdersAsync();
            return await Task.FromResult(result);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateOrderAsync([FromBody] OrderCreateCommand message)
        {
            var result = await _mediator.Send(message);
            return await Task.FromResult(result);
        }
    }
}
