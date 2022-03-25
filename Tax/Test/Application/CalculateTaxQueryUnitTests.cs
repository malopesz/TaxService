using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tax.API.Application.Queries.Interfaces;
using Tax.API.Application.ViewModels;
using Tax.Infrastructure.Dtos;

namespace Test.Application
{
    public class CalculateTaxQueryUnitTests : ICalculateTaxQuery
    {
        public Task<SalesTaxViewModel> CalculateTaxAsync(int customerId, SalesTaxRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
