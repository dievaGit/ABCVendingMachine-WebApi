using ABCVendingMachine.DataAccess;
using ABCVendingMachine.Services.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ABCVendingMachine.Services.Queries
{
    public class UsersQueryService : IUsersQueryService
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<UsersQueryService> _logger;

        public UsersQueryService(ApplicationDBContext context, ILogger<UsersQueryService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<UserDto> UserLoginAsync(LoginDto login)
        {  
                var result = (from u in _context.Users
                            where login.UserName == u.UserName && login.Pass == u.Pass
                            select new UserDto
                            {
                                UserId = u.UserId,
                                UserName = u.UserName,
                                Pass = u.Pass,
                                Role = u.Role,
                            }).FirstOrDefault();
            

            return await Task.FromResult(result);     
        }
    }
}
