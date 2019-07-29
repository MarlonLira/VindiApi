using Newtonsoft.Json;

namespace Vindi
{
    public class GatewayResponseFields
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("state")]
        public State State { get; set; }

        [JsonProperty("print_url")]
        public string PrintUrl { get; set; }

        [JsonProperty("charge_id")]
        public string ChargeId { get; set; }

        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("typeable_barcode")]
        public string TypeableBarcode { get; set; }

        [JsonProperty("nsu")]
        public string Nsu { get; set; }
    }
}