using System;
using System.Collections.Generic;

namespace Vindi
{
    class Program
    {
        static void Main(string[] args) {


            /*
            Configuration Config = new Configuration("https://app.vindi.com.br", 1, "XlZBPa4zUhX1In4T9yHloj83WNaJf0i7V386V_Q2xQk");
            Service Service = new Service(Config);*/

            Vindi Vindi = new Vindi();

            var Product = Vindi.GetByAnythingAsync(new Product());

            List<Product> products = (List<Product>)Product;

            foreach (Product product in products) {

                Console.WriteLine(product.Id + " - "+ product.Code + " - " + product.Name + " - " + product.Status);
            }

            

            

            Plan plan = new Plan() {
                Id = 114950
            };

            Customer customer = new Customer();
            customer.Id = 11082668;
            customer.Name = "José da Silva";
            customer.RegistryCode = "27721264391";

            customer = Vindi.GetByAnythingAsync(customer, true);

            PaymentMethods Pm = new PaymentMethods();
            Pm.Code = "credit_card";
            
           

            PaymentCompany Pc = new PaymentCompany();
            Pc.Code = "mastercard";
        

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
            

            var Result = Vindi.CreateAnythingAsync(Pf);

            customer = Vindi.GetByAnythingAsync(customer, true);

            Subscription Sub = new Subscription();

            Sub.Code = "5";
            Sub.Customer = customer;
            Sub.Status = "active";
            Sub.Installments = 12;
           
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        
        }
    }
}
