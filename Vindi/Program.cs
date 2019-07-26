using System;
using System.Collections.Generic;

namespace Vindi
{
    class Program
    {
        static void Main(string[] args) {

            var config = new VindiConfiguration("https://app.vindi.com.br", 1, "XlZBPa4zUhX1In4T9yHloj83WNaJf0i7V386V_Q2xQk");
            var config2 = new Configuration("https://app.vindi.com.br", 1, "XlZBPa4zUhX1In4T9yHloj83WNaJf0i7V386V_Q2xQk");

            var service = new VindiService(config);
            var service2 = new Service(config2);
            var customers = service.GetCustomersByAnythingAsync().GetAwaiter().GetResult();
            var customers2 = service2.GetByAnythingAsync(new Customer()).GetAwaiter().GetResult();
            List<Customer> Test = (List<Customer>)customers2;
            foreach (Customer Entite in Test) {
                Console.WriteLine("id: " + Entite.id + " Name: " + Entite.name + " Cpf: " + Entite.registry_code);
            }
            Plan plan = new Plan();
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

            //service.CreateCustomersAsync(Customer);
            service.UpdateCustomersAsync(Customer.id, Customer);*/

            Console.WriteLine("Hello World!");
        
        }
    }
}
