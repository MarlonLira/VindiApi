using Newtonsoft.Json;
using System;

namespace VindiSdk .Models
{
    public class MerchantUsers
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("last_sign_in_at")]
        public DateTime? LastSignInAt { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("role")]
        public Role Role { get; set; }
    }
}