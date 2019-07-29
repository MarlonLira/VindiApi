using Newtonsoft.Json;

namespace Vindi
{
    public class Gateway
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("connector")]
        public string Connector { get; set; }
    }
}