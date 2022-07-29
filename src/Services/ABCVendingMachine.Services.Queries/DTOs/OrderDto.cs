using System;
using System.Collections.Generic;
using System.Text;

namespace ABCVendingMachine.Services.Queries.DTOs
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int VendingMachineId { get; set; }
        public int WarehouseId { get; set; }
        public IEnumerable<OrderProductDetailDto> Items { get; set; } = new List<OrderProductDetailDto>();
        public DateTime CreatedAt { get; set; }
        public byte IsDeleted { get; set; }
    } 
}
