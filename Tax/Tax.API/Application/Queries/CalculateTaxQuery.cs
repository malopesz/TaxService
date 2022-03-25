using System.Collections.Generic;
using System.Threading.Tasks;
using Tax.API.Application.Queries.Interfaces;
using Tax.API.Application.ViewModels;
using Tax.Infrastructure.Dtos;
using Tax.Infrastructure.Interface;

namespace Tax.API.Application.Queries
{
    public class CalculateTaxQuery : ICalculateTaxQuery
    {
        private readonly ITaxService _taxService;

        public CalculateTaxQuery(ITaxService taxService)
        {
            _taxService = taxService;
        }

        public async Task<SalesTaxViewModel> CalculateTaxAsync(int customerId, SalesTaxRequest request)
        {
            var result = new SalesTaxViewModel()
            {
                 Tax = new ViewModels.Tax() 
                 { 
                     Breakdown = new ViewModels.Breakdown(),
                     Jurisdictions = new ViewModels.Jurisdictions()
                 }
            };

            var response = await _taxService.CalculateTaxAsync(customerId, request);

            if (response != null)
            {
                //We can use automapper here but to be quicker I'm just manually mapping (not mapping all fields as of rn)
                result.Tax.Breakdown.CityTaxableAmount = response.Tax.Breakdown.CityTaxableAmount;
                result.Tax.Breakdown.CityTaxCollectable = response.Tax.Breakdown.CityTaxCollectable;
                result.Tax.Jurisdictions.City = response.Tax.Jurisdictions.City;
                result.Tax.Jurisdictions.Country = response.Tax.Jurisdictions.Country;
                result.Tax.Jurisdictions.State = response.Tax.Jurisdictions.State;
                result.Tax.AmountToCollect = response.Tax.AmountToCollect;
                result.Tax.FreightTaxable = response.Tax.FreightTaxable;
                result.Tax.HasNexus = response.Tax.HasNexus;
                result.Tax.OrderTotalAmount = response.Tax.OrderTotalAmount;
                result.Tax.Rate = response.Tax.Rate;
                result.Tax.Shipping = response.Tax.Shipping;
                result.Tax.TaxableAmount = response.Tax.TaxableAmount;
                result.Tax.TaxSource = response?.Tax?.TaxSource;
            }

            return result;
        }

    }
}
