using ABCVendingMachine.Services.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABCVendingMachine.Services.Queries
{
    public interface IVendingMachinesQueryService
    {
        Task<List<VendingMachineDto>> GetAllVendingMachinesAsync();
        Task<List<ProductVendingMachineDto>> GetAllProductsByVendingMachineIdAsync(int vendingMachineId);
    }
}
