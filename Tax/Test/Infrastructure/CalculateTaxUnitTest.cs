using System.Threading.Tasks;
using Tax.Infrastructure.Dtos;
using Tax.Infrastructure.Exceptions;
using Xunit;

namespace Tests.TaxService
{
    public class CalculateTaxUnitTest : IClassFixture<MockTaxService>
    {
        private MockTaxService _mockTaxService;

        public CalculateTaxUnitTest(MockTaxService mockTaxService)
        {
            _mockTaxService = mockTaxService;
        }

        [Fact]
        [Trait("Category", "Infrastructure")]
        public async Task CalculateTax()
        {
            var request = new SalesTaxRequest()
            {
                Amount = 1,
                From_country = "US",
                From_state = "FL",
                From_zip = "33716",
                Shipping = 9,
                To_country = "US",
                To_state = "FL",
                To_zip = "3378"
            };
            var result = await _mockTaxService.CalculateTaxAsync(1, request);

            Assert.NotNull(result.Tax);
        }

        [Fact]
        [Trait("Category", "Infrastructure")]
        public async Task CalculateTaxInvalidRequest()
        {
            var request = new SalesTaxRequest();
            var result = await _mockTaxService.CalculateNullTaxAsync(1, request);

            Assert.Null(result.Tax);
        }
    }
}
