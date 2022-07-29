using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ABCVendingMachine.Models
{
    public class VendingMachine
    {
        [Key]
        public int VendingMachineId { get; set; }
        public string VendingMachineName { get; set; }
        public int Location { get; set; }
    }
}
