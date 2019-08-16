using Newtonsoft.Json;
using System;

namespace VindiSdk.Models
{
    public class Charge
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("due_at")]
        public DateTime? DueAt { get; set; }

        [JsonProperty("paid_at")]
        public DateTime? PaidAt { get; set; }

        [JsonProperty("installments")]
        public int? Installments { get; set; }

        [JsonProperty("attempt_count")]
        public int? AttemptCount { get; set; }

        [JsonProperty("next_attempt")]
        public object NextAttempt { get; set; }

        [JsonProperty("print_url")]
        public object PrintUrl { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("last_transaction")]
        public LastTransaction LastTransaction { get; set; }

        [JsonProperty("payment_method")]
        public PaymentMethods PaymentMethod { get; set; }

        [JsonProperty("bill")]
        public Bill Bill { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }
    }
}
