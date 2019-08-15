using Newtonsoft.Json;
using System;
using Vindi.Models;

namespace Vindi.Requesters
{
    public class CreatePlanRequester
    {
        [JsonProperty("name")]
        public string Name {
            get {
                return this.Plan.Name;
            }
        }

        [JsonProperty("interval")]
        public string Interval {
            get {
                return this.Plan.Interval;
            }
        }

        [JsonProperty("interval_count")]
        public int? IntervalCount {
            get {
                return this.Plan.IntervalCount;
            }
        }

        [JsonProperty("billing_trigger_type")]
        public string BillingTriggerType {
            get {
                return this.Plan.BillingTriggerType;
            }
        }

        [JsonProperty("billing_trigger_day")]
        public String BillingTriggerDay {
            get {
                return this.Plan.BillingTriggerDay;
            }
        }

        [JsonProperty("billing_cycles")]
        public int? BillingCycles {
            get {
                return this.Plan.BillingCycles;
            }
        }

        [JsonProperty("code")]
        public string Code {
            get {
                return this.Plan.Code;
            }
        }

        [JsonProperty("description")]
        public string Description {
            get {
                return this.Plan.Description;
            }
        }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("installments")]
        public String Installments {
            get { return this.Plan.Installments; }
        }

        [JsonProperty("invoice_split")]
        public bool InvoiceSplit {
            get {
                return this.Plan.InvoiceSplit;
            }
        }
        
        [JsonProperty("plan_items")]
        public PlanItemRequester[] PlanItems {
            get {
                Int32 Count = 0;
                PlanItemRequester[] NewPlanItems = null;
                if (Plan.PlanItems != null) {
                    NewPlanItems = new PlanItemRequester[Plan.PlanItems.Length];
                    foreach (PlanItems ItemsRequesters in Plan.PlanItems) {
                        NewPlanItems[Count] = new PlanItemRequester {
                            ProductId = ItemsRequesters.Product.Id,
                            Cycles = ItemsRequesters.Cycles
                        };
                        Count++;
                    }
                }
                return NewPlanItems;
            }
        }

        [JsonProperty("metadata")]
        public Object Metadata {
            get {
                return this.Plan.Metadata;
            }
        }

        [JsonIgnore]
        public Plan Plan { get; set; }
    }

    public class PlanItemRequester {
        
        [JsonProperty("product_id")]
        public Int32 ProductId { get; set; }

        [JsonProperty("cycles")]
        public object Cycles { get; set; }
    }
}
