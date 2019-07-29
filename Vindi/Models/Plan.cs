using Newtonsoft.Json;
using System;

namespace Vindi
{
    public class Plan
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("interval")]
        public string Interval { get; set; }

        [JsonProperty("interval_count")]
        public int? IntervalCount { get; set; }

        [JsonProperty("billing_trigger_type")]
        public string BillingTriggerType { get; set; }

        [JsonProperty("billing_trigger_day")]
        public int? BillingTriggerDay { get; set; }

        [JsonProperty("billing_cycles")]
        public int? BillingCycles { get; set; }

        [JsonProperty("code")]
        public object Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("installments")]
        public int? Installments { get; set; }

        [JsonProperty("invoice_split")]
        public bool InvoiceSplit { get; set; }

        [JsonProperty("interval_name")]
        public string IntervalName { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("plan_items")]
        public PlanItems[] PlanItems { get; set; }

        [JsonProperty("metadata")]
        public Object Metadata { get; set; }
    }
}