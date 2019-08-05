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


            Customer customer = new Customer() {
                Id = 11054368
            };

            customer = Vindi.GetByAnythingAsync(customer, true);

            Subscription Sub = new Subscription();

            Sub.Code = "5";
            Sub.Customer = customer;
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        
        }
    }
}
