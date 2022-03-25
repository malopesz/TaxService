using System.Collections.Generic;
using System.Threading.Tasks;
using Tax.Infrastructure.Dtos;

namespace Tax.Infrastructure.Interface
{
    public interface ITaxService
    {
        Task<SalesTax> CalculateTaxAsync(int customerId, SalesTaxRequest request);
        Task<TaxRate> GetTaxRateByLocationAsync(int customerId, string zip);
    }
}
