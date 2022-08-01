using ABCVendingMachine.DataAccess;
using ABCVendingMachine.Services.EventHandlers.Commands;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MediatR;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ABCVendingMachine.Models;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Threading;
using ABCVendingMachine.Services.EventHandlers.Results;

namespace ABCVendingMachine.Services.EventHandlers
{
    public class AuthenticationEventHandler
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<AuthenticationEventHandler> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        AuthenticationEventHandler(ApplicationDBContext context,
                                   ILogger<AuthenticationEventHandler> logger,
                                   SignInManager<User> signInManager,
                                   IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<AuthenticationResult> Handle(UserLoginCommand user, CancellationToken cancellationToken)
        {
            var result = new AuthenticationResult();

            try
            {
                var userLogin = await _context.Users.SingleAsync(x => x.UserName == user.UserName && x.Pass == user.Password);
                var response = await _signInManager.CheckPasswordSignInAsync(userLogin, user.Password, false);

                if (response.Succeeded)
                {
                    result.Success = true;
                    var secretKey = _configuration.GetValue<string>("SecretKey");
                    var key = Encoding.ASCII.GetBytes(secretKey);
                    var tokenHandler = new JwtSecurityTokenHandler();

                    var tokenDescriptor = new SecurityTokenDescriptor()
                    {
                        Subject = new ClaimsIdentity(
                            new Claim[]
                            {
                        new Claim(ClaimTypes.Name, user.UserName)
                            }),
                        Expires = DateTime.UtcNow.AddHours(1),
                        SigningCredentials = new SigningCredentials(
                            new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    result.AccessToken = tokenHandler.WriteToken(token);
                   
                }
                return result;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
