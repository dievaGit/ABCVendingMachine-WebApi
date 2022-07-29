using System;
using System.Collections.Generic;
using System.Text;

namespace ABCVendingMachine.Services.Queries.DTOs
{
    public class WarehouseDto
    {
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public int Location { get; set; }
    }
}
