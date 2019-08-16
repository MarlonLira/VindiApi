using Newtonsoft.Json;

namespace VindiSdk.Models
{
    public class PaymentCompanies
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}