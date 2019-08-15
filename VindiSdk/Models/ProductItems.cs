using Newtonsoft.Json;
using System;

namespace VindiSdk.Models
{
    public class ProductItems
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("product_id")]
        public int? ProductId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("cycles")]
        public object Cycles { get; set; }

        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("product")]
        public Product Product { get; set; }

        [JsonProperty("pricing_schema")]
        public PricingSchema PricingSchema { get; set; }

        [JsonProperty("discounts")]
        public object[] Discounts { get; set; }
    }
}
