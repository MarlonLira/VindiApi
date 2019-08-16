using Newtonsoft.Json;
using VindiSdk.Models;

namespace VindiSdk .Requesters
{
    public class SubscriptionRequester
    {
        #region Atributes

        [JsonProperty("plan_id")]
        public int PlanId { get; set; }

        [JsonProperty("customer_id")]
        public int CustomerId { get; set; }

        [JsonProperty("payment_method_code")]
        public string PaymentMethodCode { get; set; }

        [JsonProperty("product_items")]
        public ProductItems[] ProductItems { get; set; }

        #endregion
    }
}