using System;
using System.Collections.Generic;

namespace Vindi
{
    class Program
    {
        static void Main(string[] args) {

            var config = new Configuration("https://app.vindi.com.br", 1, "XlZBPa4zUhX1In4T9yHloj83WNaJf0i7V386V_Q2xQk");

            var service = new Service(config);
            var customers = service.GetByAnythingAsync(new Customer()).GetAwaiter().GetResult();
            var merchant_Users = service.GetByAnythingAsync(new Merchant_Users()).GetAwaiter().GetResult();
            var roles = service.GetByAnythingAsync(new Role()).GetAwaiter().GetResult();
            List<Customer> Test = (List<Customer>)customers;
            IList<Merchant_Users> Users = (IList<Merchant_Users>)merchant_Users;
            IList<Role> Lroles = (IList<Role>)roles;
            foreach (Customer Entite in Test) {
                Console.WriteLine("id: " + Entite.id + " Name: " + Entite.name + " Cpf: " + Entite.registry_code);
            }
            foreach (Merchant_Users User in Users) {
                Console.WriteLine("id: " + User.id + " Name: " + User.user + " Status: " + User.status);
            }
            foreach (Role RUser in Lroles) {
                Console.WriteLine("id: " + RUser.id + " Name: " + RUser.name + " Status: " + RUser.base_role);
            }

            Console.WriteLine("Hello World!");
        
        }
    }
}
