using System.Threading.Tasks;
using Tax.Infrastructure.Dtos;
using Tax.Infrastructure.Interface;

namespace Tests.TaxService
{
    public class MockTaxService : ITaxService
    {
        public Task<SalesTax> CalculateNullTaxAsync(int customerId, SalesTaxRequest request)
        {
            return Task.FromResult(new SalesTax());
        }

        public Task<SalesTax> CalculateTaxAsync(int customerId, SalesTaxRequest request)
        {
            return Task.FromResult(new SalesTax() {  Tax = new Tax.Infrastructure.Dtos.Tax() { Rate = 1 } });
        }

        public Task<TaxRate> GetTaxRateByLocationNullAsync(int customerId, string zip)
        {
            return Task.FromResult(new TaxRate());
        }

        public Task<TaxRate> GetTaxRateByLocationAsync(int customerId, string zip)
        {        
            return Task.FromResult(new TaxRate() { Rate = new Rate() { City = "Tampa" } });
        }
    }
}
