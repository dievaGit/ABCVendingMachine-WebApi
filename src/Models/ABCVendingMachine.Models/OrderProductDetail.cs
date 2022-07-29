using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ABCVendingMachine.Models
{
    public class OrderProductDetail
    {
        [Key]
        public int OrderProductDetailId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public byte IsDeleted { get; set; }
    }
}
