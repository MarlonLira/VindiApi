using System;
using System.Collections.Generic;
using Vindi.Models;
using Vindi.Requesters;

namespace Vindi
{
    class Program
    {
        static void Main(string[] args) {
            Vindi VindiSdk = new Vindi() {
                Config = new Configuration("https://app.vindi.com.br", 1, "XlZBPa4zUhX1In4T9yHloj83WNaJf0i7V386V_Q2xQk")
            };
            PaymentMethods PayMethodsEdit;

            Service service = new Service(VindiSdk.Config);


            //Metodo de Pagamento Debito Automatico
            /*PayMethodsEdit = new PaymentMethods() {
                Code = "bank_debit"
            };*/

            //Metodo de Pagamento Cartão de Credito
            PayMethodsEdit = new PaymentMethods() {
                Code = "credit_card"
            };

            Product NewProduct = new Product();
            NewProduct.Code = "5376";
            NewProduct.Name = "Mensalidade 54,90";
            NewProduct.PricingSchema = new PricingSchema() { Price = "54.9" };
            var Pt = service.GetByAnythingAsync(new Product());
            var Find = VindiSdk.GetByAnythingAsync(NewProduct);
        }
    }
}
