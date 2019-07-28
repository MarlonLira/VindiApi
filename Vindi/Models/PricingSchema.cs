using System;

namespace Vindi
{
    public class PricingSchema
    {
        public int id { get; set; }
        public string short_format { get; set; }
        public string price { get; set; }
        public object minimum_price { get; set; }
        public string schema_type { get; set; }
        public PricingRanges[] pricing_ranges { get; set; }
        public DateTime? created_at { get; set; }
    }

}
