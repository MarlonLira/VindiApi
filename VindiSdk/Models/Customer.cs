using Newtonsoft.Json;
using System;
using VindiSdk.Models.Models;

namespace VindiSdk.Models
{
    public class Customer
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("registry_code")]
        public string RegistryCode { get; set; }

        [JsonProperty("code")]
        public String Code { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("metadata")]
        public object Metadata { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("phones")]
        public Phone[] Phones { get; set; }
    }
}