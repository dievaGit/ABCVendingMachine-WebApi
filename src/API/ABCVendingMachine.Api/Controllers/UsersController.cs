using ABCVendingMachine.Services.EventHandlers.Commands;
using ABCVendingMachine.Services.EventHandlers.Results;
using ABCVendingMachine.Services.Queries;
using ABCVendingMachine.Services.Queries.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ABCVendingMachine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUsersQueryService _userQueryService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUsersQueryService userQueryService,
                                ILogger<UsersController> logger,
                                IMediator mediator)
        {
            _userQueryService = userQueryService;
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<UserDto> UserLoginAsync([FromBody] LoginDto login)
        {
            try
            {
                var result = await _userQueryService.UserLoginAsync(login);
                return await Task.FromResult(result);
            }
            catch
            {
                throw new Exception($"{login.UserName} not found");
            }
        }

        [HttpPost]
        [Route("token")]
        public async Task<ActionResult<AuthenticationResult>> CreateTokenAsync([FromBody]UserLoginCommand message)
        {
            var result = await _mediator.Send(message);

            return Ok(result);
        }
    }
}
