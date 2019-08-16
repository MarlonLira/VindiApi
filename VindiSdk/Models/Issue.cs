using Newtonsoft.Json;

namespace VindiSdk .Models
{
    public class Issue
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("issue_type")]
        public string IssueType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("item_type")]
        public string ItemType { get; set; }

        [JsonProperty("item_id")]
        public string ItemId { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }
    }
}