using System.Collections.Generic;
using System.Threading.Tasks;
using Tax.API.Application.Queries.Interfaces;
using Tax.API.Application.ViewModels;
using Tax.Infrastructure.Interface;

namespace Tax.API.Application.Queries
{
    public class GetTaxRateByLocationQuery : IGetTaxRateByLocationQuery
    {
        private readonly ITaxService _taxService;
        public GetTaxRateByLocationQuery(ITaxService taxService)
        {
            _taxService = taxService;
        }

        public async Task<TaxRateViewModel> GetTaxRateByLocationAsync(int customerId, string zip)
        {
            var result = new TaxRateViewModel()
            {
                 Rate = new Rate()
            };

            var response = await _taxService.GetTaxRateByLocationAsync(customerId, zip);

            if (response != null)
            {
                //We can use automapper here but to be quicker I'm just manually mapping
                result.Rate.City = response.Rate.City;
                result.Rate.CityRate = response.Rate.CityRate;
                result.Rate.CombinedDistrictRate = response.Rate.CombinedDistrictRate;
                result.Rate.CombinedRate = response.Rate.CombinedRate;
                result.Rate.County = response.Rate.County;
                result.Rate.CountyRate = response.Rate.CountyRate;
                result.Rate.FreightTaxable = response.Rate.FreightTaxable;
                result.Rate.State = response.Rate.State;
                result.Rate.StateRate = response.Rate.StateRate;
                result.Rate.Zip = response.Rate.Zip;
            }

            return result;
        }
    }
}
