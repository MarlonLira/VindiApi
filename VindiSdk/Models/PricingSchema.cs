using Newtonsoft.Json;
using System;

namespace VindiSdk.Models
{
    public class PricingSchema
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("short_format")]
        public string ShortFormat { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("minimum_price")]
        public object MinimumPrice { get; set; }

        [JsonProperty("schema_type")]
        public string SchemaType { get; set; }

        [JsonProperty("pricing_ranges")]
        public PricingRanges[] PricingRanges { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }
    }
}