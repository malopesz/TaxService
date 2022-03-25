using System.Threading.Tasks;
using Tax.API.Application.ViewModels;

namespace Tax.API.Application.Queries.Interfaces
{
    public interface IGetTaxRateByLocationQuery
    {
        Task<TaxRateViewModel> GetTaxRateByLocationAsync(int customerId, string zip);
    }
}
