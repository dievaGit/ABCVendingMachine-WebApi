using System;
using System.ComponentModel.DataAnnotations;

namespace ABCVendingMachine.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public byte IsDeleted { get; set; }
    }
}
