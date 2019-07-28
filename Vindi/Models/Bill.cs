using Newtonsoft.Json;
using System;

namespace Vindi
{

    public class Bill
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("code")]
        public object Code { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("installments")]
        public int? Installments { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("seen_at")]
        public object SeenAt { get; set; }

        [JsonProperty("billing_at")]
        public object BillingAt { get; set; }

        [JsonProperty("due_at")]
        public DateTime? DueAt { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("bill_items")]
        public BillItems[] BillItems { get; set; }

        [JsonProperty("charges")]
        public Charge[] Charges { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("period")]
        public Period Period { get; set; }

        [JsonProperty("subscription")]
        public Subscription Subscription { get; set; }

        [JsonProperty("metadata")]
        public object Metadata { get; set; }

        [JsonProperty("payment_profile")]
        public object PaymentProfile { get; set; }

        [JsonProperty("payment_condition")]
        public object PaymentCondition { get; set; }
    }

}
