using Newtonsoft.Json;

namespace Vindi.Models
{
    public class Gateway
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("connector")]
        public string Connector { get; set; }
    }
}