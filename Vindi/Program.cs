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

            PricingSchema pricingSchema = new PricingSchema();

            pricingSchema.Price = "89.9";
            pricingSchema.MinimumPrice = "89.9";



            Product NewProduct = new Product();
            NewProduct.Code = "1";
            NewProduct.Name = "89,9";
            NewProduct.PricingSchema = pricingSchema;




            PlanItems NewPlanItems = new PlanItems();
            NewPlanItems.Cycles = 1;
            NewPlanItems.Product = NewProduct;
            

            Plan NewPlan = new Plan();
            NewPlan.Name = "Plano Anual 89,9";
            NewPlan.Description = "Plano Familia";
            NewPlan.Code = 999;
            NewPlan.BillingCycles = 12;
            NewPlan.BillingTriggerDay = 0;
            NewPlan.PlanItems = new PlanItems[] { NewPlanItems };

            var CreatePlans = Service.CreateAnythingAsync(NewPlan).GetAwaiter().GetResult();


            var Plans = Service.GetByAnythingAsync(new Plan()).GetAwaiter().GetResult();

            dynamic buscar(dynamic Entidade) {
                dynamic Result = "";
                Result = Service.GetByAnythingAsync(Entidade).GetAwaiter().GetResult();
                return Result;
            }


            var Buscando = buscar(new Plan());

            List<Plan> LPlans = (List<Plan>)Plans;
            foreach (Plan Plan in LPlans) {
                Console.WriteLine("id: " + Plan.Id + " Name: " + Plan.Name + " Code: " + 
                                    Plan.Code + " Descrição: " + Plan.Description + " PlanItens: " + Plan.PlanItems[0].Product.Name +
                                    " Ciclo " + Plan.BillingCycles + " " + Plan.BillingTriggerDay + " " + Plan.BillingTriggerType);
            }

            List<Plan> LPlans2 = (List<Plan>)Buscando;
            foreach (Plan Plan in LPlans2) {
                Console.WriteLine("id: " + Plan.Id + " Name: " + Plan.Name + " Code: " +
                                    Plan.Code + " Descrição: " + Plan.Description + " PlanItens: " + Plan.PlanItems[0].Product.Name +
                                    " Ciclo " + Plan.BillingCycles + " " + Plan.BillingTriggerDay + " " + Plan.BillingTriggerType + "segundo plan");
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
