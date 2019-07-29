using Newtonsoft.Json;
using System;

namespace Vindi
{
    public class LastTransaction
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("installments")]
        public int? Installments { get; set; }

        [JsonProperty("gateway_message")]
        public string GatewayMessage { get; set; }

        [JsonProperty("gateway_response_code")]
        public object GatewayResponseCode { get; set; }

        [JsonProperty("gateway_authorization")]
        public string GatewayAuthorization { get; set; }

        [JsonProperty("gateway_transaction_id")]
        public string GatewayTransactionId { get; set; }

        [JsonProperty("gateway_response_fields")]
        public GatewayResponseFields GatewayResponseFields { get; set; }

        [JsonProperty("fraud_detector_score")]
        public object FraudDetectorScore { get; set; }

        [JsonProperty("fraud_detector_status")]
        public object FraudDetectorStatus { get; set; }

        [JsonProperty("fraud_detector_id")]
        public object FraudDetectorId { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("gateway")]
        public Gateway Gateway { get; set; }

        [JsonProperty("payment_profile")]
        public PaymentProfile PaymentProfile { get; set; }
    }
}