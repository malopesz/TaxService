using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tax.API.Application.ViewModels
{
    public class SalesTaxViewModel
    {
        [JsonPropertyName("tax")]
        public Tax Tax { get; set; }
    }

    public class Tax
    {
        [JsonPropertyName("amount_to_collect")]
        public float AmountToCollect { get; set; }

        [JsonPropertyName("breakdown")]
        public Breakdown Breakdown { get; set; }

        [JsonPropertyName("freight_taxable")]
        public bool FreightTaxable { get; set; }

        [JsonPropertyName("has_nexus")]
        public bool HasNexus { get; set; }

        [JsonPropertyName("jurisdictions")]
        public Jurisdictions Jurisdictions { get; set; }

        [JsonPropertyName("order_total_amount")]
        public float OrderTotalAmount { get; set; }

        [JsonPropertyName("rate")]
        public float Rate { get; set; }

        [JsonPropertyName("shipping")]
        public float Shipping { get; set; }

        [JsonPropertyName("tax_source")]
        public string TaxSource { get; set; }

        [JsonPropertyName("taxable_amount")]
        public float TaxableAmount { get; set; }
    }

    public class Breakdown
    {
        [JsonPropertyName("city_tax_collectable")]
        public float CityTaxCollectable { get; set; }

        [JsonPropertyName("city_tax_rate")]
        public float CityTaxRate { get; set; }

        [JsonPropertyName("city_taxable_amount")]
        public float CityTaxableAmount { get; set; }

        [JsonPropertyName("combined_tax_rate")]
        public float CombinedTaxRate { get; set; }

        [JsonPropertyName("county_tax_collectable")]
        public float CountyTaxCollectable { get; set; }

        [JsonPropertyName("county_tax_rate")]
        public float CountyTaxRate { get; set; }

        [JsonPropertyName("county_taxable_amount")]
        public float CountyTaxableAmount { get; set; }

        [JsonPropertyName("line_items")]
        public List<LineItems> LineItems { get; set; }

        [JsonPropertyName("Shipping")]
        public Shipping Shipping { get; set; }

        [JsonPropertyName("special_district_tax_collectable")]
        public float special_district_tax_collectable { get; set; }

        [JsonPropertyName("special_district_taxable_amount")]
        public float special_district_taxable_amount { get; set; }

        [JsonPropertyName("special_tax_rate")]
        public float special_tax_rate { get; set; }

        [JsonPropertyName("state_tax_collectable")]
        public float state_tax_collectable { get; set; }

        [JsonPropertyName("state_tax_rate")]
        public float state_tax_rate { get; set; }

        [JsonPropertyName("state_taxable_amount")]
        public float state_taxable_amount { get; set; }

        [JsonPropertyName("tax_collectable")]
        public float tax_collectable { get; set; }

        [JsonPropertyName("taxable_amount")]
        public float taxable_amount { get; set; }
    }

    public class LineItems
    {
        [JsonPropertyName("city_amount")]
        public float CityAmount { get; set; }

        [JsonPropertyName("city_tax_rate")]
        public float CityTaxRate { get; set; }

        [JsonPropertyName("city_taxable_amount")]
        public float CityTaxableAmount { get; set; }

        [JsonPropertyName("combined_tax_rate")]
        public float CombinedTaxRate { get; set; }

        [JsonPropertyName("county_amount")]
        public float CountyAmount { get; set; }

        [JsonPropertyName("county_tax_rate")]
        public float CountyTaxRate { get; set; }

        [JsonPropertyName("county_taxable_amount")]
        public float CountyTaxableAmount { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("special_district_amount")]
        public float SpecialDistrictAmount { get; set; }

        [JsonPropertyName("special_district_taxable_amount")]
        public float special_district_taxable_amount { get; set; }

        [JsonPropertyName("special_tax_rate")]
        public float SpecialTaxRate { get; set; }

        [JsonPropertyName("state_amount")]
        public float StateAmount { get; set; }

        [JsonPropertyName("state_sales_tax_rate")]
        public float StateSalesTaxRate { get; set; }

        [JsonPropertyName("state_taxable_amount")]
        public float StateTaxableAmount { get; set; }

        [JsonPropertyName("tax_collectable")]
        public float TaxCollectable { get; set; }

        [JsonPropertyName("taxable_amount")]
        public float TaxableAmount { get; set; }
    }

    public class Shipping
    {
        [JsonPropertyName("city_amount")]
        public float CityAmount { get; set; }

        [JsonPropertyName("city_tax_rate")]
        public float CityTaxRate { get; set; }

        [JsonPropertyName("city_taxable_amount")]
        public float CityTaxableAmount { get; set; }

        [JsonPropertyName("combined_tax_rate")]
        public float CombinedTaxRate { get; set; }

        [JsonPropertyName("county_amount")]
        public float CountyAmount { get; set; }

        [JsonPropertyName("county_tax_rate")]
        public float CountyTaxRate { get; set; }

        [JsonPropertyName("county_taxable_amount")]
        public float CountyTaxableAmount { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("special_district_amount")]
        public float SpecialDistrictAmount { get; set; }

        [JsonPropertyName("special_district_taxable_amount")]
        public float? SpecialDistrictTaxableAmount { get; set; }

        [JsonPropertyName("special_tax_rate")]
        public float SpecialTaxRate { get; set; }

        [JsonPropertyName("state_amount")]
        public float StateAmount { get; set; }

        [JsonPropertyName("state_sales_tax_rate")]
        public float StateSalesTaxRate { get; set; }

        [JsonPropertyName("state_taxable_amount")]
        public float StateTaxableAmount { get; set; }

        [JsonPropertyName("tax_collectable")]
        public float TaxCollectable { get; set; }

        [JsonPropertyName("taxable_amount")]
        public float TaxableAmount { get; set; }

        [JsonPropertyName("special_taxable_amount")]
        public float? SpecialTaxableAmount { get; set; }
    }

    public class Jurisdictions
    {
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("county")]
        public string County { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }
    }
}
