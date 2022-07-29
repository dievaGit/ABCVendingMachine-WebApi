using System;
using System.Collections.Generic;
using System.Text;

namespace ABCVendingMachine.Services.Queries.DTOs
{
    public class VendingMachineDto
    {
        public int VendingMachineId { get; set; }
        public string VendingMachineName { get; set; }
        public int Location { get; set; }
    }
}
