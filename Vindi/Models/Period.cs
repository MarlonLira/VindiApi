using Newtonsoft.Json;
using System;

namespace Vindi
{
    public class Period
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("billing_at")]
        public DateTime? BillingAt { get; set; }

        [JsonProperty("cycle")]
        public int? Cycle { get; set; }

        [JsonProperty("start_at")]
        public DateTime? StartAt { get; set; }

        [JsonProperty("end_at")]
        public DateTime? EndAt { get; set; }

        [JsonProperty("duration")]
        public int? Duration { get; set; }

        [JsonProperty("subscription")]
        public Subscription Subscription { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}