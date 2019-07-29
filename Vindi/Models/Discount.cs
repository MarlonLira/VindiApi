using Newtonsoft.Json;

namespace Vindi
{
    public class Discount
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("discount_type")]
        public string DiscountType { get; set; }

        [JsonProperty("percentage")]
        public int? Percentage { get; set; }

        [JsonProperty("amount")]
        public int? Amount { get; set; }

        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        [JsonProperty("cycles")]
        public int? Cycles { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("product_item")]
        public ProductItems ProductItem { get; set; }
    }

}