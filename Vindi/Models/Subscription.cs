using Newtonsoft.Json;
using System;

namespace Vindi.Models
{
    public class Subscription
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("start_at")]
        public DateTime? StartAt { get; set; }

        [JsonProperty("end_at")]
        public object EndAt { get; set; }

        [JsonProperty("next_billing_at")]
        public DateTime? NextBillingAt { get; set; }

        [JsonProperty("overdue_since")]
        public DateTime? OverdueSince { get; set; }

        [JsonProperty("code")]
        public object Code { get; set; }

        [JsonProperty("cancel_at")]
        public object CancelAt { get; set; }

        [JsonProperty("interval")]
        public string Interval { get; set; }

        [JsonProperty("interval_count")]
        public int? IntervalCount { get; set; }

        [JsonProperty("billing_trigger_type")]
        public string BillingTriggerType { get; set; }

        [JsonProperty("billing_trigger_day")]
        public int? BillingTriggerDay { get; set; }

        [JsonProperty("billing_cycles")]
        public object BillingCycles { get; set; }

        [JsonProperty("installments")]
        public int? Installments { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("plan")]
        public Plan Plan { get; set; }

        [JsonProperty("product_items")]
        public ProductItems[] ProductItems { get; set; }

        [JsonProperty("payment_method")]
        public PaymentMethods PaymentMethod { get; set; }

        [JsonProperty("current_period")]
        public CurrentPeriod CurrentPeriod { get; set; }

        [JsonProperty("metadata")]
        public object Metadata { get; set; }

        [JsonProperty("payment_profile")]
        public PaymentProfile PaymentProfile { get; set; }
    }
}