using System;

namespace Vindi
{
    public class Subscription
    {
        public int id { get; set; }
        public string status { get; set; }
        public DateTime? start_at { get; set; }
        public object end_at { get; set; }
        public DateTime? next_billing_at { get; set; }
        public DateTime? overdue_since { get; set; }
        public object code { get; set; }
        public object cancel_at { get; set; }
        public string interval { get; set; }
        public int? interval_count { get; set; }
        public string billing_trigger_type { get; set; }
        public int? billing_trigger_day { get; set; }
        public object billing_cycles { get; set; }
        public int? installments { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public Customer customer { get; set; }
        public Plan plan { get; set; }
        public ProductItems[] product_items { get; set; }
        public PaymentMethods payment_method { get; set; }
        public CurrentPeriod current_period { get; set; }
        public object metadata { get; set; }
        public PaymentProfile payment_profile { get; set; }
    }
}
