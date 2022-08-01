using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ABCVendingMachine.Models
{
    public class Truck
    {
        [Key]
        public int TruckId { get; set; }
        public string TruckName { get; set; }
        public int WarehouseId { get; set; }
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
