using Newtonsoft.Json;
using System;

namespace Vindi
{
    public class CurrentPeriod
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("billing_at")]
        public DateTime BillingAt { get; set; }

        [JsonProperty("cycle")]
        public int Cycle { get; set; }

        [JsonProperty("start_at")]
        public DateTime StartAt { get; set; }

        [JsonProperty("end_at")]
        public DateTime EndAt { get; set; }

        [JsonProperty("duration")]
        public int? Duration { get; set; }
    }
}
