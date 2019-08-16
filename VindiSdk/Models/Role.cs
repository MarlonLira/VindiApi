using Newtonsoft.Json;

namespace VindiSdk .Models
{
    public class Role
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("base_role")]
        public string BaseRole { get; set; }
    }
}