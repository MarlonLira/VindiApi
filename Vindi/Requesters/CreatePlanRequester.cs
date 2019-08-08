using Newtonsoft.Json;
using System;

namespace Vindi.Requesters
{
    class CreatePlanRequester
    {
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
        public string Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("installments")]
        public int? Installments { get; set; }

        [JsonProperty("invoice_split")]
        public bool InvoiceSplit { get; set; }
        
        [JsonProperty("plan_items")]
        public PlanItems[] PlanItems { get; set; }

        [JsonProperty("metadata")]
        public Object Metadata { get; set; }
    }
}
