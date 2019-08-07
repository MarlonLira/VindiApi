using System;
using System.Collections.Generic;
using Vindi.Requesters;

namespace Vindi {
    class Vindi {

        #region Configs

        private Configuration Config = new Configuration("https://app.vindi.com.br", 1, "XlZBPa4zUhX1In4T9yHloj83WNaJf0i7V386V_Q2xQk");
        private Service Service;

        #endregion

        #region Methods

        public void CreateSubscriptionRequester(Customer Customer, PaymentProfile PaymentProfile, Plan Plan) {
            SubscriptionRequester NewSub;
            Customer CustomerEdit;
            Plan PlanEdit;
            PaymentMethods PayMethodsEdit;
            PaymentProfile PayProfileEdit ;
            Vindi Vindi;
            object Result = "";
            try {

                Vindi = new Vindi();
                
                PayProfileEdit = PaymentProfile;
                PlanEdit = Plan;
                CustomerEdit = Customer;
                List<Customer> FoundClient;

                /* Pesquisa o cliente pelo CPF ou codigo caso não encontre cadastra um novo cliente pelas 
                informações passadas e da prosseguimento no processo de Assinatura */
                var FindClient = Vindi.GetByAnythingAsync(CustomerEdit, true);
                if (FindClient != null) {
                    FoundClient = (List<Customer>)FindClient;

                    if (FoundClient.Count == 1) {
                        foreach (Customer customer in FoundClient) {
                            CustomerEdit = customer;
                            break;
                        }
                    } else if (FoundClient.Count > 1) {
                        throw new Exception("Existe mais de 1(um) cadastro para esse cliente.");
                    } else if (FoundClient.Count == 0) {
                        //throw new Exception("Cliente não encontrado");
                        var NewClient = CreateAnythingAsync(CustomerEdit);
                        CustomerEdit = (Customer)NewClient;
                    }
                }

                /* Pesquisa se o plano pelo nome ou codigo caso não encontre cadastra um novo plano com as 
                informações passadas e da prosseguimento no processo de Assinatura */
                var FindPlan = GetByAnythingAsync(PlanEdit);
                if (FindPlan != null) {
                    List<Plan> FoundPlan = (List<Plan>)FindPlan;

                    if (FoundPlan.Count == 0) {
                        throw new Exception("O plano não foi encontrado.");
                    } else if (FoundPlan.Count == 1) {
                        foreach (Plan plan in FoundPlan) {
                            PlanEdit = plan;
                            break;
                        }
                    } else {
                        throw new Exception("Existem varios planos com os dados informados, por favor verifique os dados informados.");
                    }
                }

                //Metodo de Pagamento
                /*PayMethodsEdit = new PaymentMethods() {
                    Code = "bank_debit"
                };*/
                //teste
                PayMethodsEdit = new PaymentMethods() {
                    Code = "credit_card"
                };

                //Perfil de Pagamento
                if (PayProfileEdit == null) {
                    throw new Exception("Por favor Informe os dados do perfil de pagamento!");
                }
                else{
                    PayProfileEdit.PaymentMethod = PayMethodsEdit;
                }

                if (PayMethodsEdit == null) {
                    throw new Exception("Por favor Informe os dados do metodo de pagamento!");
                }

                //Assinatura
                NewSub = new SubscriptionRequester() {
                    CustomerId = CustomerEdit.Id,
                    PlanId = PlanEdit.Id,
                    PaymentMethodCode = PayMethodsEdit.Code
                };

                Result = Vindi.CreateAnythingAsync(NewSub);
            } catch (Exception Except) {
                Console.WriteLine(Except.Message);
            }
        }

        public dynamic GetByAnythingAsync(dynamic Entitie, Boolean IsForQUery = false, Boolean IsById = false) {
            Service = new Service(Config);
            dynamic Result = "";
            if (IsById == false) {
                Result = Service.GetByAnythingAsync(Entitie, IsForQUery);
            }
            else if (IsById == true) {
                Result = Service.GetByIdAnythingAsync(Entitie).GetAwaiter().GetResult();
            }
            return Result;
        }

        public dynamic CreateAnythingAsync(dynamic Entitie) {
            Service = new Service(Config);
            dynamic Result = "";
            try {
                Result = Service.CreateAnythingAsync(Entitie).GetAwaiter().GetResult();
            } catch (Exception Excep) {
                throw new Exception(Excep.Message);
            }
            return Result;
        }

        public dynamic UpdateAnythingAsync(dynamic Entitie) {
            Service = new Service(Config);
            dynamic Result = "";
            Result = Service.UpdateAnythingAsync(Entitie).GetAwaiter().GetResult();
            return Result;
        }

        public dynamic DeleteAnythingAsync(dynamic Entitie) {
            Service = new Service(Config);
            dynamic Result = "";
            Result = Service.DeleteAnythingAsync(Entitie).GetAwaiter().GetResult();
            return Result;
        }

        #endregion
    }
}
