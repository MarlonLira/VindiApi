﻿namespace Vindi
{
    public class ImportBatche
    {
        public int id { get; set; }
        public string status { get; set; }
        public int? batch_file_name { get; set; }
        public int? batch_file_size { get; set; }
        public int? batch_fingerprint { get; set; }
        public string url { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public PaymentMethods payment_method { get; set; }
    }
}
