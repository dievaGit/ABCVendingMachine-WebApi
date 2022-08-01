using System;
using System.Collections.Generic;
using System.Text;

namespace ABCVendingMachine.Services.EventHandlers.Commands
{
    public class AccessTokenCommand
    {
        public bool Success { get; set; }
        public string AccessToken { get; set; }
    }
}
