using System;
using System.Collections.Generic;
using System.Text;

namespace Vindi
{
    class Test
    {
    }

    public class Rootobject
    {
        public Subscription[] subscriptions { get; set; }
        public Plan[] plans { get; set; }
        public Product[] products { get; set; }
        public PaymentMethods[] payment_methods { get; set; }
        public Period[] periods { get; set; }

        public Bill[] bills { get; set; }

        public Charge[] charges { get; set; }
        public Invoice[] invoices { get; set; }
        public Message[] messages { get; set; }
        public ImportBatche[] import_batches { get; set; }
        public Issue[] issues { get; set; }
        public Notification[] notifications { get; set; }
        public Merchant[] merchants { get; set; }
        public MerchantUsers[] merchant_users { get; set; }

        public Role[] roles { get; set; }

    }












}
