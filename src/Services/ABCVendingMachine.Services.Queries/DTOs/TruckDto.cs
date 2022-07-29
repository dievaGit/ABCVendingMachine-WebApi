using System;
using System.Collections.Generic;
using System.Text;

namespace ABCVendingMachine.Services.Queries.DTOs
{
    public class TruckDto
    {
        public int TruckId { get; set; }
        public string TruckName { get; set; }
        public int WarehouseId { get; set; }
    }
}
