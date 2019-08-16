using Newtonsoft.Json;

namespace VindiSdk .Models
{
    public class ImportBatche
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("batch_file_name")]
        public int? BatchFileName { get; set; }

        [JsonProperty("batch_file_size")]
        public int? BatchFileSize { get; set; }

        [JsonProperty("batch_fingerprint")]
        public int? BatchFingerprint { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("payment_method")]
        public PaymentMethods PaymentMethod { get; set; }
    }
}