using System;
using System.Collections.Generic;
using Vindi.Requesters;

namespace Vindi
{
    class Program
    {
        static void Main(string[] args) {


            /*
            Configuration Config = new Configuration("https://app.vindi.com.br", 1, "XlZBPa4zUhX1In4T9yHloj83WNaJf0i7V386V_Q2xQk");
            Service Service = new Service(Config);*/
            /*
            

            //1
            var Product = Vindi.GetByAnythingAsync(new Product());

            List<Product> products = (List<Product>)Product;

            Product Product2 = new Product();
            foreach (Product product in products) {
                Product2 = product;
                Console.WriteLine(product.Id + " - "+ product.Code + " - " + product.Name + " - " + product.Status);
            }

            //2
            ProductItems PItens = new ProductItems();
            PItens.Product = Product2;

            Plan plan = new Plan() {
                Id = 114950
            };

            //3
            Customer customer = new Customer();
            customer.Id = 11082668;
            customer.Name = "José da Silva";
            customer.RegistryCode = "27721264391";

            customer = Vindi.GetByAnythingAsync(customer, true);
            //3
            PaymentMethods Pm = new PaymentMethods();
            Pm.Code = "credit_card";

            PaymentCompany Pc = new PaymentCompany();
            Pc.Code = "mastercard";

            //4
            PaymentProfile Pf = new PaymentProfile();
            Pf.RegistryCode = "27721264391";
            Pf.HolderName = "José da Silva";
            Pf.Customer = customer;
            Pf.PaymentCompany = Pc;
            Pf.PaymentMethod = Pm;
            Pf.CardNumber = "5167454851671773";
            Pf.CardExpiration = "12/2019";
            Pf.CardCvv = "123";

            var Profile = Vindi.GetByAnythingAsync(new PaymentProfile());

            //var Result = Vindi.CreateAnythingAsync(Pf);

            customer = Vindi.GetByAnythingAsync(customer, true);

            //5
            SubscriptionRequester Sub = new SubscriptionRequester();

            Sub.CustomerId = customer.Id;
            Sub.PlanId = plan.Id;
            Sub.PaymentMethodCode = Pm.Code;

            var SubResult = Vindi.CreateAnythingAsync(Sub);*/
            Vindi Vindi = new Vindi();
            Customer Cliente = new Customer();
            Cliente.RegistryCode = "79089806008";
            Cliente.Name = "Carlos Duarte";
            Cliente.Code = "777888";
            Cliente.Email = "cbduarte@gmail.com";

            Customer Cliente2 = new Customer();
            Cliente2.RegistryCode = "76907119013";

            Plan Plan = new Plan();
            Plan.Name = "Anual livre 99,90";

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

            //var Result2 = Vindi.DeleteSubscription(Cliente2);
            var Result = Vindi.CreateSubscriptionRequester(Cliente2, Plan, Pf);

            Subscription Sub = (Subscription)Result;
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        
        }
        
        
    }
}
