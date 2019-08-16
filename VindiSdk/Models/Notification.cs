using Newtonsoft.Json;
using System;

namespace VindiSdk .Models
{
    public class Notification
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("notification_type")]
        public string NotificationType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("trigger_type")]
        public string TriggerType { get; set; }

        [JsonProperty("trigger_day")]
        public int? TriggerDay { get; set; }

        [JsonProperty("bcc")]
        public object Bcc { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}