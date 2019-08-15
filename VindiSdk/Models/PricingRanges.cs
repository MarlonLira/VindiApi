using Newtonsoft.Json;

namespace VindiSdk.Models
{
    public class PricingRanges
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("start_quantity")]
        public int? StartQuantity { get; set; }

        [JsonProperty("end_quantity")]
        public int? EndQuantity { get; set; }

        [JsonProperty("price")]
        public int? Price { get; set; }

        [JsonProperty("overage_price")]
        public int? OveragePrice { get; set; }
    }
}