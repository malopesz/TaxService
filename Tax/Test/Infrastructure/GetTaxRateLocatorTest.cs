using System.Threading.Tasks;
using Tax.Infrastructure.Exceptions;
using Tests.TaxService;
using Xunit;

namespace Test.Infrastructure
{
    public class GetTaxRateLocatorTest : IClassFixture<MockTaxService>
    {
        private MockTaxService _mockTaxService;

        public GetTaxRateLocatorTest(MockTaxService mockTaxService)
        {
            _mockTaxService = mockTaxService;
        }

        [Fact]
        [Trait("Category", "Infrastructure")]
        public async Task GetTaxRateByLocation()
        {
            var result = await _mockTaxService.GetTaxRateByLocationAsync(1, "33716");

            Assert.NotNull(result.Rate);
        }

        [Fact]
        [Trait("Category", "Infrastructure")]
        public async Task GetTaxRateByLocationInvalidZip()
        {
            var result = await _mockTaxService.GetTaxRateByLocationNullAsync(1, "");

            Assert.Null(result.Rate);
        }
    }
}
