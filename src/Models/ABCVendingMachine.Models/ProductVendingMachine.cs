using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ABCVendingMachine.Models
{
    public class ProductVendingMachine
    {
        [Key]
        public int ProductVendingMachineId { get; set; }
        public int VendingMachineId { get; set; }
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public DateTime InventoryDay { get; set; }
        public byte IsDeleted { get; set; }
    }
}
