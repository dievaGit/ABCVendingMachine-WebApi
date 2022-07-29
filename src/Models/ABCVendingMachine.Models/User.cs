using System;
using System.Collections.Generic;
using System.Text;

namespace ABCVendingMachine.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string Role { get; set; }
    }
}
