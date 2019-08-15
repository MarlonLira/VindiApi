using Newtonsoft.Json;
using System;

namespace Vindi.Models
{
    public class Transaction
    {
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        [JsonProperty("transaction_type")]
        public String TransactionType { get; set; }

        [JsonProperty("status")]
        public String Status { get; set; }

        [JsonProperty("amount")]
        public String Amount { get; set; }

        [JsonProperty("installments")]
        public Int32 Installments { get; set; }

        [JsonProperty("gateway_message")]
        public String GatewayMessage { get; set; }

        [JsonProperty("gateway_response_code")]
        public String GatewayResponseCode { get; set; }

        [JsonProperty("gateway_authorization")]
        public String GatewayAuthorization { get; set; }

        [JsonProperty("gateway_transaction_id")]
        public String GatewayTransactionId { get; set; }

        [JsonProperty("gateway_response_fields")]
        public Object GatewayResponseFields { get; set; }

        [JsonProperty("fraud_detector_score")]
        public Int32 FraudDetectorScore { get; set; }

        [JsonProperty("fraud_detector_status")]
        public String FraudDetectorStatus { get; set; }

        [JsonProperty("fraud_detector_id")]
        public Int32 FraudDetectorId { get; set; }

        [JsonProperty("created_at")]
        public String CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public String UpdatedAt { get; set; }

        [JsonProperty("gateway")]
        public Gateway Gateway { get; set; }

        [JsonProperty("payment_profile")]
        public PaymentProfile PaymentProfile { get; set; }

        [JsonProperty("charge")]
        public Charge Charge { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("payment_method")]
        public PaymentMethods PaymentMethod { get; set; }
    }
}
