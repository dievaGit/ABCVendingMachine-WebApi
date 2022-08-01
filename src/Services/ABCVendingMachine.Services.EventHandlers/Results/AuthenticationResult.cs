using System;
using System.Collections.Generic;
using System.Text;

namespace ABCVendingMachine.Services.EventHandlers.Results
{
    public class AuthenticationResult
    {
        public bool Success { get; set; }
        public string AccessToken { get; set; }
    }
}
