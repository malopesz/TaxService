using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Tax.Infrastructure.Dtos
{
    public class TaxRate
    {
        [JsonPropertyName("rate")]
        public Rate Rate { get; set; }
    }

    public class Rate
    {
        [JsonPropertyName("zip")]
        public string Zip { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("state_rate")]
        public string StateRate { get; set; }

        [JsonPropertyName("county")]
        public string County { get; set; }

        [JsonPropertyName("county_rate")]
        public string CountyRate { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("city_rate")]
        public string CityRate { get; set; }

        [JsonPropertyName("combined_district_rate")]
        public string CombinedDistrictRate { get; set; }

        [JsonPropertyName("combined_rate")]
        public string CombinedRate { get; set; }

        [JsonPropertyName("freight_taxable")]
        public bool FreightTaxable { get; set; }
    }
}
