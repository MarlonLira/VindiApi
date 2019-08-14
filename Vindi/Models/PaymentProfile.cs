using Newtonsoft.Json;
using System;

namespace Vindi.Models
{
    public class PaymentProfile
    {
        
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("holder_name")]
        public string HolderName { get; set; }

        [JsonProperty("registry_code")]
        public object RegistryCode { get; set; }

        [JsonProperty("bank_branch")]
        public object BankBranch { get; set; }

        [JsonProperty("bank_account")]
        public object BankAccount { get; set; }

        [JsonProperty("card_expiration")]
        public String CardExpiration { get; set; }

        
        [JsonProperty("card_number_first_six")]
        public string CardNumberFirstSix { get; set; }

        
        [JsonProperty("card_number_last_four")]
        public string CardNumberLastFour { get; set; }

        
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("gateway_token")]
        public string GatewayToken { get; set; }

        
        [JsonProperty("type")]
        public string Type { get; set; }

        
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        
        [JsonProperty("payment_company")]
        public PaymentCompany PaymentCompany { get; set; }

        
        [JsonProperty("payment_method")]
        public PaymentMethods PaymentMethod { get; set; }

        
        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("customer_id")]
        public Int32 CustomerId {
            get {
                Customer NewCustomer = new Customer() { Id = 0};
                if (Customer != null) {
                    NewCustomer = Customer;
                }
                return NewCustomer.Id;
            }
        }

        [JsonProperty("payment_method_code")]
        public String PaymentMethodCode {
            get {
                String NewPaymentMethodCode = "";
                if (PaymentMethod != null) {
                    NewPaymentMethodCode = PaymentMethod.Code;
                }

                return NewPaymentMethodCode;
            }
            set {
                if (PaymentMethod != null) {
                    PaymentMethod.Code = value;
                } else {
                    throw new Exception("A entidade PaymentMethod não pode estar nula");
                }
            }

        }

        [JsonProperty("payment_company_code")]
        public String PaymentCompanyCode {
            get {
                String NewPaymentCompanyCode = "";
                if (PaymentCompany != null) {
                    NewPaymentCompanyCode = PaymentCompany.Code;
                }
                return NewPaymentCompanyCode;
            }

            set {
                if (PaymentCompany != null) {
                    PaymentCompany.Code = value;
                } else {
                    throw new Exception("A entidade PaymentCompany não pode estar nula");
                }
            }
        }

        [JsonProperty("card_number")]
        public String CardNumber { get; set; }

        [JsonProperty("card_cvv")]
        public String CardCvv { get; set; }
    }
}