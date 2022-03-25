using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tax.Infrastructure.Dtos
{
    public class SalesTaxRequest
    {
        [JsonPropertyName("from_country")]
        public string From_country { get; set; }

        [JsonPropertyName("from_zip")]
        public string From_zip { get; set; }

        [JsonPropertyName("from_state")]
        public string From_state { get; set; }

        [JsonPropertyName("to_country")]
        public string To_country { get; set; }

        [JsonPropertyName("to_zip")]
        public string To_zip { get; set; }

        [JsonPropertyName("to_state")]
        public string To_state { get; set; }

        [JsonPropertyName("amount")]
        public float Amount { get; set; }

        [JsonPropertyName("shipping")]
        public float Shipping { get; set; }

        [JsonPropertyName("line_items")]
        public List<LineItemsRequest> Line_items { get; set; }

    }

    public class LineItemsRequest
    {
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("unit_price")]
        public float Unit_price { get; set; }

        [JsonPropertyName("product_tax_code")]
        public string Product_tax_code { get; set; }
    }
}
