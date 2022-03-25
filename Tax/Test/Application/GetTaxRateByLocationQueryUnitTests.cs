using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tax.API.Application.Queries.Interfaces;
using Tax.API.Application.ViewModels;

namespace Test.Application
{
    public class GetTaxRateByLocationQueryUnitTests : IGetTaxRateByLocationQuery
    {
        public Task<TaxRateViewModel> GetTaxRateByLocationAsync(int customerId, string zip)
        {
            throw new NotImplementedException();
        }
    }
}
