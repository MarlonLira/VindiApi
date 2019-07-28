using Newtonsoft.Json;

namespace Vindi
{
    public class Phone
    {
        [JsonProperty("phone_type")]
        public string PhoneType { get; set; }
        public string number { get; set; }
        public string extension { get; set; }
    }
}
