using Vindi;


namespace Vindi.Requesters
{
    public class CreateProductItemRequester
    {
        #region Atributes

        public int product_id { get; set; }
        public int subscription_id { get; set; }
        public int cycles { get; set; }
        public int quantity { get; set; }
        public PricingSchema pricing_schema { get; set; }

        #endregion
    }


}
