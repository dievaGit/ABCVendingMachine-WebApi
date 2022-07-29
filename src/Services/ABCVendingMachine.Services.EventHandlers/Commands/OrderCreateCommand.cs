using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABCVendingMachine.Services.EventHandlers.Commands
{
    public class OrderCreateCommand : IRequest<bool>
    {
        public int OrderId { get; set; }
        public int VendingMachineId { get; set; }
        public int WarehouseId { get; set; }
        public IEnumerable<DetailOrderProduct> Items { get; set; } = new List<DetailOrderProduct>();
        public DateTime CreatedAt { get; set; }
    }

    public class DetailOrderProduct
    {
        public int OrderProductDetailId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
