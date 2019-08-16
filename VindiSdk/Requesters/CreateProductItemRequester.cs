using Newtonsoft.Json;
using VindiSdk.Models;

namespace VindiSdk .Requesters
{
    public class CreateProductItemRequester
    {
        #region Atributes

        [JsonProperty("product_id")]
        public int ProductId { get; set; }

        [JsonProperty("subscription_id")]
        public int SubscriptionId { get; set; }

        [JsonProperty("cycles")]
        public int Cycles { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("pricing_schema")]
        public PricingSchema PricingSchema { get; set; }

        #endregion
    }
}