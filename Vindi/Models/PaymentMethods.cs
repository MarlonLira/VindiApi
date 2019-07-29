using Newtonsoft.Json;
using System;

namespace Vindi
{
    public class PaymentMethods
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("public_name")]
        public string PublicName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("settings")]
        public Settings Settings { get; set; }

        [JsonProperty("set_subscription_on_success")]
        public string SetSubscriptionOnSuccess { get; set; }

        [JsonProperty("allow_as_alternative")]
        public bool AllowAsAlternative { get; set; }

        [JsonProperty("payment_companies")]
        public PaymentCompanies[] PaymentCompanies { get; set; }

        [JsonProperty("maximum_attempts")]
        public int? MaximumAttempts { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}