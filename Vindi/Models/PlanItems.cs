using Newtonsoft.Json;
using System;

namespace Vindi
{
    public class PlanItems
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("product")]
        public Product Product { get; set; }

        [JsonProperty("cycles")]
        public object Cycles { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}