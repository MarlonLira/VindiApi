using Newtonsoft.Json;

namespace VindiSdk.Models
{
    public class Settings
    {
        [JsonProperty("automatic_bill_charge")]
        public bool AutomaticBillCharge { get; set; }

        [JsonProperty("due_days")]
        public object DueDays { get; set; }

        [JsonProperty("require_gateway")]
        public bool RequireGateway { get; set; }

        [JsonProperty("bank_slip_type")]
        public string BankSlipType { get; set; }

        [JsonProperty("branch")]
        public string Branch { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("additional_instructions")]
        public string AdditionalInstructions { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("contract_number")]
        public string ContractNumber { get; set; }

        [JsonProperty("payment_company_id")]
        public string PaymentCompanyId { get; set; }

        [JsonProperty("dynamic")]
        public bool Dynamic { get; set; }

        [JsonProperty("require_registration")]
        public bool RequireRegistration { get; set; }

        [JsonProperty("defer_registration")]
        public bool DeferRegistration { get; set; }

        [JsonProperty("document_type")]
        public string DocumentType { get; set; }

        [JsonProperty("voidable")]
        public bool Voidable { get; set; }
    }
}