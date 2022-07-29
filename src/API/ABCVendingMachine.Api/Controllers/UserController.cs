using ABCVendingMachine.Services.Queries;
using ABCVendingMachine.Services.Queries.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ABCVendingMachine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserQueryService _userQueryService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserQueryService userQueryService, ILogger<UserController> logger)
        {
            _userQueryService = userQueryService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<UserDto> UserLogin(LoginDto login)
        {
            try
            {
                var result = await _userQueryService.UserLogin(login);
                return await Task.FromResult(result);
            }
            catch
            {
                throw new Exception($"{login.UserName} not found");
            }
        }
    }
}
