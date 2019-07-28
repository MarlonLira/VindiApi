using System;

namespace Vindi
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string unit { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public string invoice { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public PricingSchema pricing_schema { get; set; }
        public object metadata { get; set; }
    }
}
