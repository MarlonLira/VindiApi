using Newtonsoft.Json;
using System;

namespace Vindi
{
    public class PaymentProfile
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("holder_name")]
        public string HolderName { get; set; }

        [JsonProperty("registry_code")]
        public object RegistryCode { get; set; }

        [JsonProperty("bank_branch")]
        public object BankBranch { get; set; }

        [JsonProperty("bank_account")]
        public object BankAccount { get; set; }

        [JsonProperty("card_expiration")]
        public DateTime? CardExpiration { get; set; }

        [JsonProperty("card_number_first_six")]
        public string CardNumberFirstSix { get; set; }

        [JsonProperty("card_number_last_four")]
        public string CardNumberLastFour { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("gateway_token")]
        public string GatewayToken { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("payment_company")]
        public PaymentCompany PaymentCompany { get; set; }

        [JsonProperty("payment_method")]
        public PaymentMethods PaymentMethod { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }
    }
}