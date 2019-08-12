using System;
using System.Collections.Generic;
using Vindi.Requesters;

namespace Vindi
{
    class Program
    {
        static void Main(string[] args) {
            Vindi Vindi = new Vindi();
            PaymentMethods PayMethodsEdit;

            //Metodo de Pagamento Debito Automatico
            /*PayMethodsEdit = new PaymentMethods() {
                Code = "bank_debit"
            };*/

            //Metodo de Pagamento Cartão de Credito
            PayMethodsEdit = new PaymentMethods() {
                Code = "credit_card"
            };

            Product NewProduct = new Product();
            NewProduct.Code = "5876";
            NewProduct.Name = "Mensalidade 59,90";
            NewProduct.PricingSchema = new PricingSchema() { Price = "59.9" };

            //NewProduct = (Product)Vindi.CreateAnythingAsync(NewProduct);
            var Products = Vindi.GetByAnythingAsync(NewProduct, true);
            List<Product> FindProduct = (List<Product>)Products;
            foreach (Product ProductEdit in FindProduct) {
                NewProduct = ProductEdit;
                break;
            }

            Customer Cliente = new Customer();
            Cliente.RegistryCode = "79089806008";
            Cliente.Name = "Carlos Duarte";
            Cliente.Code = "777888";
            Cliente.Email = "cbduarte@gmail.com";

            Customer Cliente2 = new Customer();
            Cliente2.RegistryCode = null;
            Cliente2.Code = "6685855";

            var findCliente2 = Vindi.GetByAnythingAsync(Cliente2, true);

            PlanItems planItems = new PlanItems();
            planItems.Product = NewProduct;

            Plan Plan = new Plan();
            Plan.Name = "Anual livre 59,90";
            Plan.Code = "82299";
            Plan.BillingCycles = 12;
            Plan.BillingTriggerType = "beginning_of_period";
            Plan.Interval = "months";
            Plan.IntervalName = "Mensalidade";
            Plan.IntervalCount = 1;
            Plan.Installments = "1";
            Plan.BillingTriggerDay = "0";
            Plan.PlanItems = new PlanItems[] { planItems };

            /*CreatePlanRequester createPlan = new CreatePlanRequester();
            createPlan.Plan = Plan;*/
            /*
            var Re = Vindi.CreateAnythingAsync(createPlan);*/

            PaymentCompany Pc = new PaymentCompany();
            Pc.Code = "visa";

            PaymentProfile Pf = new PaymentProfile();
            Pf.RegistryCode = "79089806008";
            Pf.HolderName = "Carlos Duarte";
            Pf.Customer = Cliente;
            Pf.PaymentCompany = Pc;
            Pf.CardNumber = "4444444444444448";
            Pf.CardExpiration = "12/2019";
            Pf.CardCvv = "123";
            Pf.PaymentMethod = PayMethodsEdit;

            var Result2 = Vindi.DeleteSubscription(Cliente2);
            var Result = Vindi.CreateSubscriptionRequester(Cliente2, Plan, Pf);

            Subscription Sub = (Subscription)Result;
            Console.WriteLine("Code: " + "\n Cliente: " + Sub.Customer.Name + " /n CPF: " + "\n Plano: " + Sub.Plan.Name + "\n Preço: ");
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        
        }
        
        
    }
}
