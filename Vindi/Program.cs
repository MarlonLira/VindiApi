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



            /*
            var plans = service.GetPlansByAnythingAsync().GetAwaiter().GetResult();
            var plans2 = service2.GetByAnythingAsync(new Plan()).GetAwaiter().GetResult();
            var products = service.GetProductsByAnythingAsync().GetAwaiter().GetResult();
            var paymentMethods = service.GetPaymentMethoidsByAnythingAsync().GetAwaiter().GetResult();
            var subscriptions = service.GetSubscriptionsByAnythingAsync().GetAwaiter().GetResult();
            var bills = service.GetBillsByAnythingAsync().GetAwaiter().GetResult();
            var charges = service.GetChargesByAnythingAsync().GetAwaiter().GetResult();
            var invoices = service.GetInvoicesByAnythingAsync().GetAwaiter().GetResult();
            var messages = service.GetMessagesByAnythingAsync().GetAwaiter().GetResult();
            var importBatches = service.GetImportBatchesByAnythingAsync().GetAwaiter().GetResult();
            var issues = service.GetIssuesByAnythingAsync().GetAwaiter().GetResult();
            var notifications = service.GetNotificationsByAnythingAsync().GetAwaiter().GetResult();
            var merchant_Users = service.GetMerchantUsersByAnythingAsync().GetAwaiter().GetResult();
            var roles = service.GetRolesByAnythingAsync().GetAwaiter().GetResult();
            /*Customer Customer = new Customer() {
                id = 11054586,
                name="juspencio silva"
            };
            

           */

            Console.WriteLine("Hello World!");
        
        }
    }
}
