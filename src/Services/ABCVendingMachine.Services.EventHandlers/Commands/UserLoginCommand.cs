using ABCVendingMachine.Services.EventHandlers.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABCVendingMachine.Services.EventHandlers.Commands
{
    public class UserLoginCommand : IRequest<AuthenticationResult>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
