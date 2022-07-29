using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ABCVendingMachine.Models
{
    public class ProductWarehouse
    {
        [Key]
        public int ProductWarehouseId { get; set; }
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public DateTime InventoryDay { get; set; }
        public byte IsDeleted { get; set; }
    }
}
