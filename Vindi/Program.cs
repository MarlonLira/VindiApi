using System;
using System.Collections.Generic;

namespace Vindi
{
    class Program
    {
        static void Main(string[] args) {

            Configuration Config = new Configuration("https://app.vindi.com.br", 1, "XlZBPa4zUhX1In4T9yHloj83WNaJf0i7V386V_Q2xQk");
            Service Service = new Service(Config);

            var customers = Service.GetByAnythingAsync(new Customer()).GetAwaiter().GetResult();
            var merchant_Users = Service.GetByAnythingAsync(new MerchantUsers()).GetAwaiter().GetResult();
            var roles = Service.GetByAnythingAsync(new Role()).GetAwaiter().GetResult();
            List<Customer> Test = (List<Customer>)customers;
            IList<MerchantUsers> Users = (IList<MerchantUsers>)merchant_Users;
            IList<Role> Lroles = (IList<Role>)roles;
            foreach (Customer Entite in Test) {
                Console.WriteLine("id: " + Entite.Id + " Name: " + Entite.Name + " Cpf: " + Entite.RegistryCode);
            }
            foreach (MerchantUsers User in Users) {
                Console.WriteLine("id: " + User.Id + " Name: " + User.User + " Status: " + User.Status);
            }
            foreach (Role RUser in Lroles) {
                Console.WriteLine("id: " + RUser.Id + " Name: " + RUser.Name + " Status: " + RUser.BaseRole);
            }
            /*

            Phone phone = new Phone() {
                number = "81985658525",
                phone_type = "Cel",
                extension = "+55"
            };


            Customer Cliente = new Customer() {
                Name = "Pingado Pato da Silva",
                RegistryCode = "00259931004",
                Email = "pingado@gmail.com"
            };

            var newCliente = Service.CreateAnythingAsync(Cliente).GetAwaiter().GetResult();

            if (newCliente != null) {
                Console.WriteLine("Nome:" + newCliente.Name + " - CPF: " + newCliente.RegistryCode);
            }*/

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        
        }
    }
}
