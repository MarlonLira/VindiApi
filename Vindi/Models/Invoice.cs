using Newtonsoft.Json;
using System;

namespace Vindi.Models
{
    public class Invoice
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("amount")]
        public decimal? Amount { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("integration_invoice_id")]
        public string IntegrationInvoiceId { get; set; }

        [JsonProperty("integration_reference")]
        public string IntegrationReference { get; set; }

        [JsonProperty("print_url")]
        public string PrintUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("settings")]
        public string Settings { get; set; }

        [JsonProperty("issued_at")]
        public DateTime? IssuedAt { get; set; }

        [JsonProperty("scheduled_at")]
        public DateTime? ScheduledAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("bill")]
        public Bill Bill { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }
    }
}