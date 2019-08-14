using Newtonsoft.Json;

namespace Vindi.Models
{
    class Error
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("parameter")]
        public string Parameter { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
