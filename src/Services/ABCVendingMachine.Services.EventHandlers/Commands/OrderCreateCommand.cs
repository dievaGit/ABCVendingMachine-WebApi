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
        public IEnumerable<DetailOrderProductComand> Items { get; set; } = new List<DetailOrderProductComand>();
        public DateTime CreatedAt { get; set; }
    }

}
