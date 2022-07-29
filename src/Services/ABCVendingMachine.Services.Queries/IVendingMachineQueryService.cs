using ABCVendingMachine.Services.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABCVendingMachine.Services.Queries
{
    public interface IVendingMachineQueryService
    {
        Task<List<VendingMachineDto>> GetAllVendingMachine();
        Task<List<ProductVendingMachineDto>> GetInventoryVendingMachine(int vendingMachineId);
    }
}
