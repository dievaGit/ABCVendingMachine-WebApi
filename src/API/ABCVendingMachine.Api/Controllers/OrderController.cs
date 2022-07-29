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
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderQueryService _orderQueryService;

        public OrderController(IMediator mediator, ILogger<OrderController> logger, IOrderQueryService orderQueryService)
        {
            _mediator = mediator;
            _logger = logger;
            _orderQueryService = orderQueryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>>GetAllOrder()
        {
            var result = await _orderQueryService.GetAllOrder();
            return await Task.FromResult(result);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateOrder(OrderCreateCommand message)
        {
            var result = await _mediator.Send(message);
            return await Task.FromResult(result);
        }
    }
}
