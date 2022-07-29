using System;
using System.Collections.Generic;
using System.Text;

namespace ABCVendingMachine.Services.Queries.DTOs
{
    public class ProductVendingMachineDto
    {
        public int ProductVendingMachineId { get; set; }
        public int VendingMachineId { get; set; }
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
