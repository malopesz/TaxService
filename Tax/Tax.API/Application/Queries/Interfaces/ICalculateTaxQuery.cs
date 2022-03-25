using System.Threading.Tasks;
using Tax.API.Application.ViewModels;
using Tax.Infrastructure.Dtos;

namespace Tax.API.Application.Queries.Interfaces
{
    public interface ICalculateTaxQuery
    {
        Task<SalesTaxViewModel> CalculateTaxAsync(int customerId, SalesTaxRequest request);
    }
}
