using Newtonsoft.Json;
using System;

namespace Vindi.Models
{
    public class Message
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("notification_type")]
        public string NotificationType { get; set; }

        [JsonProperty("seen_at")]
        public object SeenAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("charge")]
        public Charge Charge { get; set; }

        [JsonProperty("notification")]
        public Notification Notification { get; set; }
    }
}