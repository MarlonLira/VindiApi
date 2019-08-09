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

        public dynamic CreateSubscriptionRequester(Customer Customer, Plan Plan, PaymentProfile PayMentProfile = null) {
            SubscriptionRequester NewSub;
            Subscription SubEdit;
            Customer CustomerEdit;
            CreatePlanRequester PlanResquester;
            Plan PlanEdit;
            PlanItems[] PlanItemsEdit;
            PaymentMethods PayMethodsEdit;
            PaymentProfile PayProfileEdit;
            DateTime CurrentDate = DateTime.UtcNow.AddHours(-3);
            dynamic Result;
            try {
                PayProfileEdit = PayMentProfile;
                PlanEdit = Plan;
                PlanItemsEdit = PlanEdit.PlanItems;
                CustomerEdit = Customer;
                List<Customer> FoundClient;

                /* Pesquisa o cliente pelo CPF ou codigo caso não encontre cadastra um novo cliente 
                 * pelas informações passadas e da prosseguimento no processo de Assinatura 
                 */
                if (!String.IsNullOrEmpty(CustomerEdit.RegistryCode) || !String.IsNullOrEmpty(CustomerEdit.Code)) {
                    var FindClient = GetByAnythingAsync(CustomerEdit, true);
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
                            //Cria um novo Cliente
                            var NewClient = CreateAnythingAsync(CustomerEdit);
                            CustomerEdit = (Customer)NewClient;
                        }
                    }
                }

                /* Pesquisa se o cliente possui um perfil de pagamendo disponivel pelo id ou cpf caso não encontre 
                 * tenta cadastra um novo perfil de pagamento com as informações passadas e da prosseguimento no processo de Assinatura caso consiga 
                 */
                if (PayProfileEdit == null) {
                    PayProfileEdit = new PaymentProfile();
                }

                PayProfileEdit.Customer = CustomerEdit;
                var FindPayProfile = GetByAnythingAsync(PayProfileEdit, true);
                if (FindPayProfile != null) {
                    List<PaymentProfile> FoundPaymentProfiles = (List<PaymentProfile>)FindPayProfile;

                    if (FoundPaymentProfiles.Count == 0) {
                        //Cria um perfil de pagamento para o cliente, caso tenha sido passada as informações necessarias.
                        if (PayMentProfile != null) {
                            var NewPayProfile = CreateAnythingAsync(PayMentProfile);
                            PayProfileEdit = (PaymentProfile)NewPayProfile;
                        } else {
                            throw new Exception("Não foi possivel criar um perfil de pagamento para o cliente, verifique os dados fornecidos.");
                        }
                    } else if (FoundPaymentProfiles.Count > 1) {
                        throw new Exception("O cliente só pode possuir 1(um) perfil de pagamento ativo, e possui: " + FoundPaymentProfiles.Count + " perfis ativos, Entre em contato com o suporte para fazer a devida correção.");
                    }else if (FoundPaymentProfiles.Count == 1) {
                        foreach (PaymentProfile paymentProfile in FoundPaymentProfiles) {
                            PayProfileEdit = paymentProfile;
                            break;
                        }
                    }
                }

                /* Pesquisa se o plano pelo nome ou codigo caso não encontre tenta cadastra um novo plano 
                 * com as informações passadas e da prosseguimento no processo de Assinatura caso consiga
                 */
                var FindPlan = GetByAnythingAsync(PlanEdit, true);
                
                if (FindPlan != null) {
                    List<Plan> FoundPlan = (List<Plan>)FindPlan;

                    if (FoundPlan.Count == 0) {

                        /* Pesquisa se o produto informado no plano pelo preço ou codigo caso não encontre tenta cadastra 
                         * um novo produto com as informações passadas e da prosseguimento no processo de Assinatura caso consiga
                         */
                        Int32 Count = 0;
                        foreach (PlanItems PItens in PlanItemsEdit) {
                            var FindProduct = GetByAnythingAsync(PItens.Product, true);
                            List<Product> FoundProduct = (List<Product>)FindProduct;
                            if (FoundProduct.Count > 0) {
                                foreach (Product product in FoundProduct) {
                                    PlanItemsEdit[Count].Product = product;
                                }
                            } else {
                                var NewProduct = CreateAnythingAsync(PlanItemsEdit[Count].Product);
                                PlanItemsEdit[Count].Product = (Product)NewProduct;
                            }
                        }
                       
                        PlanResquester = new CreatePlanRequester();

                        PlanEdit.PlanItems = PlanItemsEdit;
                        PlanResquester.Plan = PlanEdit;
                        var NewPlan = CreateAnythingAsync(PlanResquester);
                        PlanEdit = (Plan)NewPlan;
                    } else if (FoundPlan.Count == 1) {
                        foreach (Plan plan in FoundPlan) {
                            PlanEdit = plan;
                            break;
                        }
                    } else {
                        throw new Exception("Foi encontrado mais de um plano, por favor verifique os dados informados, ou refine sua busca");
                    }
                }

                //Metodo de Pagamento Debito Automatico
                /*PayMethodsEdit = new PaymentMethods() {
                    Code = "bank_debit"
                };*/

                //Metodo de Pagamento Cartão de Credito
                PayMethodsEdit = new PaymentMethods() {
                    Code = "credit_card"
                };

                /* Pesquisa se o aluno já possui uma assinatura, caso possua verifica se possui 
                 * um determinado numero de dias para o fim da assinatura, caso não possua o processo de assinatura continua normalmente.
                 */
                SubEdit = new Subscription();
                SubEdit.Customer = CustomerEdit;
                var FindSubscription = GetByAnythingAsync(SubEdit, true);
                List<Subscription> FoundSubscription = (List<Subscription>)FindSubscription;

                if (FoundSubscription.Count == 1) {
                    foreach (Subscription subscription in FoundSubscription) {
                        SubEdit = subscription;
                        break;
                    }

                    if (Convert.ToDateTime(SubEdit.EndAt) > CurrentDate.AddDays(46)) {
                        throw new Exception("O aluno informado possui uma assinatura vingente com mais de 45 dias para o termino, com vigencia final para: " + Convert.ToString(Convert.ToDateTime(SubEdit.EndAt)));
                    }
                }else if (FoundSubscription.Count > 1) {
                    throw new Exception("O aluno possui mais de uma assinatura, contate o suporte");
                }

                NewSub = new SubscriptionRequester() {
                    CustomerId = CustomerEdit.Id,
                    PlanId = PlanEdit.Id,
                    PaymentMethodCode = PayMethodsEdit.Code
                };

                Result = CreateAnythingAsync(NewSub);
            } catch (Exception Except) {
                throw new Exception(Except.Message);
            }
            return Result;
        }

        public dynamic DeleteSubscription(Customer Customer) {
            Customer CustomerEdit;
            Subscription SubEdit;
            dynamic Result;
            try {
                /*Procura o aluno pelo cpf ou codigo informado na entidade Customer*/
                CustomerEdit = Customer;
                List<Customer> FoundClient;
                
                if (!String.IsNullOrEmpty(CustomerEdit.RegistryCode) || !String.IsNullOrEmpty(CustomerEdit.Code)) {
                    var FindClient = GetByAnythingAsync(CustomerEdit, true);

                    if (FindClient != null) {
                        FoundClient = (List<Customer>)FindClient;

                        if (FoundClient.Count == 1) {
                            foreach (Customer customer in FoundClient) {
                                CustomerEdit = customer;
                                break;
                            }
                        }
                    }
                } else {
                    throw new Exception("Os dados do aluno não foram informados");
                }

                /*Procura a assinatura usando o id do aluno recuperado acima*/
                SubEdit = new Subscription();
                SubEdit.Customer = CustomerEdit;
                var FindSubscription = GetByAnythingAsync(SubEdit, true);
                List<Subscription> FoundSubscription = (List<Subscription>)FindSubscription;
                if (FoundSubscription.Count == 1) {
                    foreach (Subscription subscription in FoundSubscription) {
                        SubEdit = subscription;
                        break;
                    }
                }else if (FoundSubscription.Count == 0) {
                    throw new Exception("O cliente informado não possui assinatura!");
                }else if (FoundSubscription.Count > 1) {
                    throw new Exception("O cliente informado possui mais de uma assinatura ativa, entre em contato com o suporte.");
                }

                /*Cancela a assinatura usando o id da assinatura recuperado acima*/
               Result = DeleteAnythingAsync(SubEdit);
            } catch (Exception Except) {
                throw new Exception(Except.Message);
            }
            return Result;
        }
        public dynamic GetByAnythingAsync(dynamic Entitie, Boolean IsForQUery = false, Boolean IsById = false) {
            Service = new Service(Config);
            dynamic Result;
            if (IsById == false) {
                Result = Service.GetByAnythingAsync(Entitie, IsForQUery);
            }
            else {
                Result = Service.GetByIdAnythingAsync(Entitie).GetAwaiter().GetResult();
            }
            return Result;
        }

        public dynamic CreateAnythingAsync(dynamic Entitie) {
            Service = new Service(Config);
            dynamic Result;
            try {
                Result = Service.CreateAnythingAsync(Entitie).GetAwaiter().GetResult();
            } catch (Exception Excep) {
                throw new Exception(Excep.Message);
            }
            return Result;
        }

        public dynamic UpdateAnythingAsync(dynamic Entitie) {
            Service = new Service(Config);
            dynamic Result;
            Result = Service.UpdateAnythingAsync(Entitie).GetAwaiter().GetResult();
            return Result;
        }

        public dynamic DeleteAnythingAsync(dynamic Entitie) {
            Service = new Service(Config);
            dynamic Result;
            Result = Service.DeleteAnythingAsync(Entitie).GetAwaiter().GetResult();
            return Result;
        }

        #endregion
    }
}
