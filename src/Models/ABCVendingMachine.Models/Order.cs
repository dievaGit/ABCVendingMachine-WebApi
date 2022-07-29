using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ABCVendingMachine.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int VendingMachineId { get; set; }
        public int WarehouseId { get; set; }
        public IEnumerable<OrderProductDetail> Items { get; set; } = new List<OrderProductDetail>();
        public DateTime CreatedAt { get; set; }
        public byte IsDeleted { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
