﻿using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using VindiSdk.Models;

namespace VindiSdk {
    class Program
    {
        static void Main(string[] args) {

            try {
                Vindi VindiSdk = new Vindi() {
                    Config = new Configuration("https://app.vindi.com.br", 1, "XlZBPa4zUhX1In4T9yHloj83WNaJf0i7V386V_Q2xQk")
                };
                PaymentMethods PayMethodsEdit;

                /*int d = 5000;

                var result = SearchByIdAsync().GetAwaiter().GetResult();

                async Task<dynamic> SearchByIdAsync() {
                    ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => { return true; };
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    return await $@"{VindiSdk.Config.UrlApi + "/api/v1"}/{"products"}/{479020}"
                   .WithBasicAuth(Convert.ToString(VindiSdk.Config.Authorization), "")
                   .GetJsonAsync();
                };*/
                    
                //Metodo de Pagamento Debito Automatico
                /*PayMethodsEdit = new PaymentMethods() {
                    Code = "bank_debit"
                };*/

                //Metodo de Pagamento Cartão de Credito
                PayMethodsEdit = new PaymentMethods() {
                    Code = "credit_card"
                };

                Product NewProduct = new Product();
                NewProduct.Code = "5375556";
                NewProduct.Name = "Mensalidade 51,90";
                NewProduct.PricingSchema = new PricingSchema() { Price = "51.9" };
                
                var Find2 = VindiSdk.GetByAnythingAsync(NewProduct, true);

                var Find = VindiSdk.GetByAnythingAsync(NewProduct);
                NewProduct = (Product)VindiSdk.CreateAnythingAsync(NewProduct);

                Console.WriteLine();
                Console.ReadKey();
                
                var Products = VindiSdk.GetByAnythingAsync(NewProduct, true);
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
                Cliente.Phones = new Phone[] {
                 new Phone() {
                      Number = "81985665588"
                 }
            };

                var re = VindiSdk.CreateAnythingAsync(Cliente);

                Customer Cliente2 = new Customer();
                Cliente2.RegistryCode = "09177350480";
                Cliente2.Code = "6685855";

                var findCliente2 = VindiSdk.GetByAnythingAsync(Cliente2, true);

                PlanItems planItems = new PlanItems();
                planItems.Product = NewProduct;

                Plan Plan = new Plan();
                Plan.Name = "Anual livre 54,90";
                Plan.Code = "79299";
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
                var Re = VindiSdk.CreateAnythingAsync(createPlan);*/

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

                //var Result2 = VindiSdk.DeleteSubscription(Cliente2);
                var Result = VindiSdk.CreateSubscriptionRequester(Cliente2, Plan, Pf);

                Subscription Sub = (Subscription)Result;
                List<Subscription> LSub = new List<Subscription>() { Sub };
                Console.WriteLine(LSub.ToString());
                Console.WriteLine("Hello World!");
                Console.ReadKey();
            } catch (Exception Except) {
                Console.WriteLine(Except.Message);
            }
        
        }
        
        
    }
}
