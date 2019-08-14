using Newtonsoft.Json;

namespace Vindi.Models
{
    public class BillItems
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        [JsonProperty("pricing_range_id")]
        public object PricingRangeId { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("pricing_schema")]
        public PricingSchema PricingSchema { get; set; }

        [JsonProperty("product")]
        public Product Product { get; set; }

        [JsonProperty("product_item")]
        public ProductItems ProductItem { get; set; }

        [JsonProperty("discount")]
        public object Discount { get; set; }
    }
}
