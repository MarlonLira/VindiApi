using Newtonsoft.Json;

namespace Vindi
{
    public class Phone
    {
        [JsonProperty("phone_type")]
        public string PhoneType { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }
    }
}
