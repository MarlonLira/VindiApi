namespace Vindi.Requesters
{
    public class SubscriptionRequester
    {
        #region Atributes

        public int plan_id { get; set; }
        public int customer_id { get; set; }
        public string payment_method_code { get; set; }
        public ProductItems[] product_items { get; set; }

        #endregion
    }
}
