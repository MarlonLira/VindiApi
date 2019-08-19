using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vindi.Helpers;
using Vindi.Requesters;
using Vindi.Models;
using System.Net;

namespace Vindi
{
    public class Service
    {

        #region Atributes

        private Object Authorization;
        private String UrlApi;
        private FlurlExceptionHlp FExceptionHlp;

        #endregion

        #region Constructor

        public Service(Configuration Config) {
            this.UrlApi = $@"{Config.UrlApi}/api/v{Config.Version}";
            this.Authorization = Config.Authorization;
        }

        #endregion

        #region Others
        private async Task<dynamic> DeleteByIdAndQueryAsync(String Uri, Int32 Id, IDictionary<FilterSearch, String> Query = null) {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var queryString = QueryString(Query);
            return await $@"{UrlApi}/{Uri}/{Id}{(String.IsNullOrEmpty(queryString) ? String.Empty : queryString.Substring(1))}"
                .WithBasicAuth(Convert.ToString(Authorization), "").AllowAnyHttpStatus()
                .DeleteAsync()
                .ReceiveJson();
        }
        private async Task<dynamic> DeleteByIdAsync(String Uri, Int32 Id) {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            dynamic Result = "";
            try {
                Result = await $@"{UrlApi}/{Uri}/{Id}"
                   .WithBasicAuth(Convert.ToString(Authorization), "").AllowAnyHttpStatus()
                   .DeleteAsync()
                   .ReceiveJson();
            } catch (FlurlHttpException Except) {
                FExceptionHlp = new FlurlExceptionHlp();
                String ExceptResult = FExceptionHlp.ConvertToString(Except);
                throw new Exception(ExceptResult);
            }

            return Result;
        }
        private async Task<dynamic> PostByAnythingBodyAsync(String Uri, String Param, String Action) {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            dynamic Result = "";
            try {
                Result = await $@"{UrlApi}/{Uri}/{Param}/{Action}"
                    .WithBasicAuth(Convert.ToString(Authorization), "")
                    .PostAsync(null)
                    .ReceiveJson();
            } catch (FlurlHttpException Except) {
                FExceptionHlp = new FlurlExceptionHlp();
                String ExceptResult = FExceptionHlp.ConvertToString(Except);
                throw new Exception(ExceptResult);
            }

            return Result;
        }

        private async Task<dynamic> PostByAnythingAsync(String Uri, Object Requster) {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            dynamic Result = "";
            try {
                Result = await $@"{UrlApi}/{Uri}"
                    .WithBasicAuth(Convert.ToString(Authorization), "")
                    .PostJsonAsync(Requster)
                    .ReceiveJson();
            } catch (FlurlHttpException Except) {
                FExceptionHlp = new FlurlExceptionHlp();
                String ExceptResult = FExceptionHlp.ConvertToString(Except);
                throw new Exception(ExceptResult);
            }
            return Result;
        }
        private async Task<dynamic> PutByAnythingAsync(String Uri, Object Requster) {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            dynamic Result = "";
            try {
                Result = await $@"{UrlApi}/{Uri}"
                   .WithBasicAuth(Convert.ToString(Authorization), "")
                   .PutJsonAsync(Requster)
                   .ReceiveJson();
            } catch (FlurlHttpException Except) {
                FExceptionHlp = new FlurlExceptionHlp();
                String ExceptResult = FExceptionHlp.ConvertToString(Except);
                throw new Exception(ExceptResult);
            }
            return Result;
        }
        private async Task<dynamic> PutByIdAsync(String Uri, Int32 Id, Object Requester) {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            dynamic Result = "";
            try {
                Result = await $@"{UrlApi}/{Uri}/{Id}"
                    .WithBasicAuth(Convert.ToString(Authorization), "")
                    .PutJsonAsync(Requester).ReceiveJson();
            } catch (FlurlHttpException Except) {
                FExceptionHlp = new FlurlExceptionHlp();
                String ExceptResult = FExceptionHlp.ConvertToString(Except);
                throw new Exception(ExceptResult);
            }
            return Result;
        }
        private static T FromDynamicTo<T>(dynamic d) where T : class {
            var p = JsonConvert.SerializeObject(d);
            if (p.StartsWith("["))
                return JArray.Parse(p).ToObject<T>();
            return JObject.Parse(p).ToObject<T>();
        }
        private static string QueryString(IDictionary<FilterSearch, String> Query)
            => Query != null ? $"&query={String.Join(" ", Query.Select(x => $"{x.Key.ToString()}:{x.Value}"))}" : String.Empty;

        private async Task<dynamic> SearchByAnythingAsync(String Uri, IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            dynamic Result = "";
            try {
                Result = await $@"{UrlApi}/{Uri}?Page={Page}&per_Page={PerPage}&sort_by={filterSearch.ToString()}&sort_order={sortOrder.ToString()}{QueryString(Query)}"
                   .WithBasicAuth(Convert.ToString(Authorization), "")
                   .GetJsonAsync();
            } catch (FlurlHttpException Except) {
                FExceptionHlp = new FlurlExceptionHlp();
                String ExceptResult = FExceptionHlp.ConvertToString(Except);
                throw new Exception(ExceptResult);
            }
            return Result;
        }
        private async Task<dynamic> SearchByIdAsync(String Uri, Int32 Id) {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            return await $@"{UrlApi}/{Uri}/{Id}"
                .WithBasicAuth(Convert.ToString(Authorization), "")
                .GetJsonAsync();
        }

        #endregion

        #region Get Methods

        //Retorna todos as transações
        public async Task<IEnumerable<Transaction>> GetByAnythingAsync(Transaction Transaction, IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("transactions", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Transaction>>(list?.transactions);
        }

        //Retorna a transação pelo id informado
        public async Task<Product> GetByIdAnythingAsync(Transaction Transaction) {
            var result = await SearchByIdAsync("transactions", Transaction.Id);
            return FromDynamicTo<Product>(result?.transaction);
        }

        //Pesquisa as transações de um cliente pelo id da cobrança(Todas as transações da cobrança informada) ou id do cliente(Todas as trnasações do cliente).
        public dynamic GetByAnythingAsync(Transaction Transaction, Boolean IsforQuery) {
            dynamic Result = null;
            IDictionary<FilterSearch, String> Query;
            try {
                if (IsforQuery == true) {
                    Query = new Dictionary<FilterSearch, String>();
                    if (Transaction.Charge.Id > 0) {
                        Query.Add(FilterSearch.charge_id, Convert.ToString(Transaction.Charge.Id));
                    } else if (Transaction.Customer.Id > 0) {
                        Query.Add(FilterSearch.customer_id, Convert.ToString(Transaction.Customer.Id));
                    }

                    Result = GetByAnythingAsync(Transaction, Query, 1, 20, FilterSearch.created_at, SortOrder.desc).GetAwaiter().GetResult();
                } else {
                    Result = GetByAnythingAsync(Transaction, null, 1, 20, FilterSearch.created_at, SortOrder.desc).GetAwaiter().GetResult();
                }
            } catch (FlurlHttpException Except) {
                throw new Exception(Except.Message);
            }
            return Result;
        }

        //Retorna todos os produtos
        public async Task<IEnumerable<Product>> GetByAnythingAsync(Product Product, IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("products", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Product>>(list?.products);
        }

        //Retorna o produto pelo id informado
        public async Task<Product> GetByIdAnythingAsync(Product Product) {
            var result = await SearchByIdAsync("products", Product.Id);
            return FromDynamicTo<Product>(result?.product);
        }

        //Retorna o item do produto pelo id informado
        public async Task<ProductItems> GetByIdAnythingAsync(ProductItems ProductItems) {
            var result = await SearchByIdAsync("product_items", ProductItems.Id);
            return FromDynamicTo<ProductItems>(result?.product_item);
        }

        //Pesquisa o produto pelo preço ou nome informado.
        public dynamic GetByAnythingAsync(Product Product, Boolean IsforQuery) {
            dynamic Result = null;
            IDictionary<FilterSearch, String> Query;
            try {
                if (IsforQuery == true) {
                    Query = new Dictionary<FilterSearch, String>();
                    if (!String.IsNullOrEmpty(Product.PricingSchema.Price)) {
                        Query.Add(FilterSearch.price, Product.PricingSchema.Price);
                    } else if (!String.IsNullOrEmpty(Product.Name)) {
                        Query.Add(FilterSearch.name, Product.Name);
                    }

                    Result = GetByAnythingAsync(Product, Query).GetAwaiter().GetResult();
                } else {
                    Result = GetByAnythingAsync(Product).GetAwaiter().GetResult();
                }
            } catch (FlurlHttpException Except) {
                throw new Exception(Except.Message);
            }
            return Result;
        }

        //Retorna todos os Planos
        public async Task<IEnumerable<Plan>> GetByAnythingAsync(Plan Plan, IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("plans", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Plan>>(list?.plans);
        }

        //Retorna o plano pelo id informado
        public async Task<Plan> GetByIdAnythingAsync(Plan Plan) {
            var result = await SearchByIdAsync("plans", Plan.Id);
            return FromDynamicTo<Plan>(result?.plan);
        }

        //Pesquisa o plano pelo nome ou codigo informado.
        public dynamic GetByAnythingAsync(Plan Plan, Boolean IsforQuery) {
            dynamic Result = null;
            IDictionary<FilterSearch, String> Query;
            try {
                if (IsforQuery == true) {
                    Query = new Dictionary<FilterSearch, String>();
                    if (!String.IsNullOrEmpty(Plan.Code)) {
                        Query.Add(FilterSearch.code, Plan.Code);
                        Result = GetByAnythingAsync(Plan, Query).GetAwaiter().GetResult();
                    } else {
                        Result = new List<Plan>();
                    }

                    if (!String.IsNullOrEmpty(Plan.Name) && (Result.Count <= 0 || Result.Count > 1)) {
                        if (Result.Count < 1) {
                            Query.Clear();
                        }
                        Query.Add(FilterSearch.name, "'" + Plan.Name + "'");
                        Result = GetByAnythingAsync(Plan, Query).GetAwaiter().GetResult();
                    }

                } else {
                    Result = GetByAnythingAsync(Plan).GetAwaiter().GetResult();
                }
            } catch (FlurlHttpException Except) {
                throw new Exception(Except.Message);
            }
            return Result;
        }

        //Retorna todos os clientes
        public async Task<IEnumerable<Customer>> GetByAnythingAsync(Customer Customer, IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("customers", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Customer>>(list?.customers);
        }

        //Pesquisa o Cliente pelo CPF ou Codigo informado.
        public dynamic GetByAnythingAsync(Customer Customer, Boolean IsforQuery) {
            dynamic Result = null;
            IDictionary<FilterSearch, String> Query;
            try {
                if (IsforQuery == true) {
                    Query = new Dictionary<FilterSearch, String>();
                    if (!String.IsNullOrEmpty(Customer.RegistryCode)) {
                        Query.Add(FilterSearch.registry_code, Customer.RegistryCode);
                        Result = GetByAnythingAsync(Customer, Query).GetAwaiter().GetResult();
                    } else {
                        Result = new List<Customer>();
                    }

                    if (!String.IsNullOrEmpty(Customer.Code) && (Result.Count <= 0 || Result.Count > 1)) {
                        if (Result.Count < 1) {
                            Query.Clear();
                        }

                        Query.Add(FilterSearch.code, Customer.Code);
                        Result = GetByAnythingAsync(Customer, Query).GetAwaiter().GetResult();
                    }
                } else {
                    Result = GetByAnythingAsync(Customer).GetAwaiter().GetResult();
                }
            } catch (FlurlHttpException Except) {
                throw new Exception(Except.Message);
            }
            return Result;
        }

        //Retorna o cliente pelo id informado
        public async Task<Customer> GetByIdAnythingAsync(Customer Customer) {
            var result = await SearchByIdAsync("customers", Customer.Id);
            return FromDynamicTo<Customer>(result?.customer);
        }

        //Retorna todas as assinaturas
        public async Task<IEnumerable<Subscription>> GetByAnythingAsync(Subscription Subscription, IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("subscriptions", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Subscription>>(list?.subscriptions);
        }

        //Retorna a assinatura pelo id informado
        public async Task<Subscription> GetByIdAnythingAsync(Subscription Subscription) {
            var result = await SearchByIdAsync("subscriptions", Subscription.Id);
            return FromDynamicTo<Subscription>(result?.subscription);
        }

        //Pesquisa a assinatura de um cliente pelo id do cliente informado.
        public dynamic GetByAnythingAsync(Subscription Subscription, Boolean IsforQuery) {
            dynamic Result = null;
            IDictionary<FilterSearch, String> Query;
            try {
                if (IsforQuery == true) {
                    Query = new Dictionary<FilterSearch, String>();
                    if (Subscription.Customer.Id > 0) {
                        Query.Add(FilterSearch.customer_id, Convert.ToString(Subscription.Customer.Id));
                        Query.Add(FilterSearch.status, "active");
                    }
                    Result = GetByAnythingAsync(Subscription, Query).GetAwaiter().GetResult();
                } else {
                    Result = GetByAnythingAsync(Subscription).GetAwaiter().GetResult();
                }
            } catch (FlurlHttpException Except) {
                throw new Exception(Except.Message);
            }
            return Result;
        }

        //Retorna todos os periodos
        public async Task<IEnumerable<Period>> GetByAnythingAsync(Period Period, IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("periods", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Period>>(list?.periods);
        }

        //Retorna o periodo pelo id informado
        public async Task<Period> GetByIdAnythingAsync(Period Period) {
            var result = await SearchByIdAsync("periods", Period.Id);
            return FromDynamicTo<Period>(result?.period);
        }

        //Retorna todos os metodos de Pagamento
        public async Task<IEnumerable<PaymentMethods>> GetByAnythingAsync(PaymentMethods PaymentMethods, IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("payment_methods", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<PaymentMethods>>(list?.payment_methods);
        }

        //Retorna o metodo de Pagamento pelo id informado
        public async Task<PaymentMethods> GetByIdAnythingAsync(PaymentMethods PaymentMethods) {
            var result = await SearchByIdAsync("payment_methods", PaymentMethods.Id);
            return FromDynamicTo<PaymentMethods>(result?.payment_method);
        }

        //Retorna todos os perfis de pagamento
        public async Task<IEnumerable<PaymentProfile>> GetByAnythingAsync(PaymentProfile PaymentProfile, IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("payment_profiles", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<PaymentProfile>>(list?.payment_profiles);
        }

        //Retorna o perfil de pagamento pelo id informado
        public async Task<PaymentProfile> GetByIdAnythingAsync(PaymentProfile PaymentProfile) {
            var result = await SearchByIdAsync("payment_profiles", PaymentProfile.Id);
            return FromDynamicTo<PaymentProfile>(result?.payment_profile);
        }

        //Pesquisa o perfil de pagamento de uma cliente pelo id do cliente ou cpf informado.
        public dynamic GetByAnythingAsync(PaymentProfile PaymentProfile, Boolean IsforQuery) {
            dynamic Result = null;
            IDictionary<FilterSearch, String> Query;
            try {
                if (IsforQuery == true) {
                    Query = new Dictionary<FilterSearch, String>();
                    if (PaymentProfile.CustomerId > 0) {
                        Query.Add(FilterSearch.customer_id, Convert.ToString(PaymentProfile.CustomerId));
                        Query.Add(FilterSearch.status, "active");
                    } else if (!String.IsNullOrEmpty(PaymentProfile.Customer.RegistryCode)) {
                        Query.Add(FilterSearch.registry_code, PaymentProfile.Customer.RegistryCode);
                        Query.Add(FilterSearch.status, "active");
                    }

                    Result = GetByAnythingAsync(PaymentProfile, Query).GetAwaiter().GetResult();
                } else {
                    Result = GetByAnythingAsync(PaymentProfile).GetAwaiter().GetResult();
                }
            } catch (FlurlHttpException Except) {
                throw new Exception(Except.Message);
            }
            return Result;
        }

        //Retorna todas as cobranças
        public async Task<IEnumerable<Charge>> GetByAnythingAsync(Charge Charge, IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.created_at, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("charges", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Charge>>(list?.charges);
        }

        //Retorna a cobranças pelo id informado
        public async Task<Charge> GetByIdAnythingAsync(Charge Charge) {
            var result = await SearchByIdAsync("charges", Charge.Id);
            return FromDynamicTo<Charge>(result?.charge);
        }

        //Pesquisa as Cobranças de um cliente pelo id da fatura(Todas as cobranças da fatura informada) ou id do cliente(Todas as cobranças do cliente).
        public dynamic GetByAnythingAsync(Charge Charge, Boolean IsforQuery) {
            dynamic Result = null;
            IDictionary<FilterSearch, String> Query;
            try {
                if (IsforQuery == true) {
                    Query = new Dictionary<FilterSearch, String>();
                    if (Charge.Bill.Id > 0) {
                        Query.Add(FilterSearch.bill_id, Convert.ToString(Charge.Bill.Id));
                    } else if (Charge.Customer.Id > 0) {
                        Query.Add(FilterSearch.customer_id, Convert.ToString(Charge.Customer.Id));
                    }

                    Result = GetByAnythingAsync(Charge, Query).GetAwaiter().GetResult();
                } else {
                    Result = GetByAnythingAsync(Charge).GetAwaiter().GetResult();
                }
            } catch (FlurlHttpException Except) {
                throw new Exception(Except.Message);
            }
            return Result;
        }

        //Retorna todas as faturas
        public async Task<IEnumerable<Bill>> GetByAnythingAsync(Bill Bill, IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("bills", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Bill>>(list?.bills);
        }

        //Retorna a faturas pelo id informado
        public async Task<Bill> GetByIdAnythingAsync(Bill Bill) {
            var result = await SearchByIdAsync("bills", Bill.Id);
            return FromDynamicTo<Bill>(result?.bill);
        }

        //Retorna o item da fatura pelo id do item informado
        public async Task<BillItems> GetByIdAnythingAsync(BillItems Bill_Items) {
            var result = await SearchByIdAsync("bill_items", Bill_Items.Id);
            return FromDynamicTo<BillItems>(result?.bill_item);
        }

        //Pesquisa as faturas de um cliente pelo id da assinatura(Todas da assinatura informada) ou id do cliente(Todas do cliente).
        public dynamic GetByAnythingAsync(Bill Bill, Boolean IsforQuery) {
            dynamic Result = null;
            IDictionary<FilterSearch, String> Query;
            try {
                if (IsforQuery == true) {
                    Query = new Dictionary<FilterSearch, String>();
                    if (Bill.Subscription.Id > 0) {
                        Query.Add(FilterSearch.subscription_id, Convert.ToString(Bill.Subscription.Id));
                    } else if (Bill.Customer.Id > 0) {
                        Query.Add(FilterSearch.customer_id, Convert.ToString(Bill.Customer.Id));
                    }

                    Result = GetByAnythingAsync(Bill, Query, 1, 20, FilterSearch.id, SortOrder.desc).GetAwaiter().GetResult();
                } else {
                    Result = GetByAnythingAsync(Bill, null, 1, 20, FilterSearch.id, SortOrder.desc).GetAwaiter().GetResult();
                }
            } catch (FlurlHttpException Except) {
                throw new Exception(Except.Message);
            }
            return Result;
        }

        //Retorna o Desconto pelo id informado.
        public async Task<Discount> GetByIdAnythingAsync(Discount Discount) {
            var result = await SearchByIdAsync("discounts", Discount.Id);
            return FromDynamicTo<Discount>(result?.discount);
        }

        //Retorna todos os lotes de importação.
        public async Task<IEnumerable<ImportBatche>> GetByAnythingAsync(ImportBatche ImportBatche, IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("import_batches", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<ImportBatche>>(list?.import_batches);
        }

        //Retorna o lote de importação pelo id informado.
        public async Task<ImportBatche> GetByIdAnythingAsync(ImportBatche ImportBatche) {
            var result = await SearchByIdAsync("import_batches", ImportBatche.Id);
            return FromDynamicTo<ImportBatche>(result?.import_batche);
        }

        //Retorna todas as notas fiscais.
        public async Task<IEnumerable<Invoice>> GetByAnythingAsync(Invoice Invoice, IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("invoices", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Invoice>>(list?.invoices);
        }

        //Retorna a nota fiscal pelo id informado.
        public async Task<Invoice> GetByIdAnythingAsync(Invoice Invoice) {
            var result = await SearchByIdAsync("invoices", Invoice.Id);
            return FromDynamicTo<Invoice>(result?.invoice);
        }

        //Retorna todas as pendencias.
        public async Task<IEnumerable<Issue>> GetByAnythingAsync(Issue Issue, IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("issues", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Issue>>(list?.issues);
        }

        //Retorna uma pedencia pelo id informado.
        public async Task<Issue> GetByIdAnythingAsync(Issue Issue) {
            var result = await SearchByIdAsync("issues", Issue.Id);
            return FromDynamicTo<Issue>(result?.issue);
        }

        //Retorna todas as empresas cadastradas
        public async Task<IEnumerable<Merchant>> GetByAnythingAsync(Merchant Merchant, IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("merchants", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Merchant>>(list?.merchants);
        }

        //Retorna a empresa cadastrada pelo id informado
        public async Task<Merchant> GetByIdAnythingAsync(Merchant Merchant) {
            var result = await SearchByIdAsync("merchants", Merchant.Id);
            return FromDynamicTo<Merchant>(result?.merchant);
        }

        //Retorna todos os usuarios associados cadastrados.
        public async Task<IEnumerable<MerchantUsers>> GetByAnythingAsync(MerchantUsers MerchantUsers, IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("merchant_users", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<MerchantUsers>>(list?.merchant_users);
        }

        //Retorna os usuarios associados pelo id informado.
        public async Task<MerchantUsers> GetByIdAnythingAsync(MerchantUsers MerchantUsers) {
            var result = await SearchByIdAsync("merchant_users", MerchantUsers.Id);
            return FromDynamicTo<MerchantUsers>(result?.merchant_user);
        }

        //Retorna todas as mensagens.
        public async Task<IEnumerable<Message>> GetByAnythingAsync(Message Message, IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("messages", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Message>>(list?.messages);
        }

        //Retorna um mensagem pelo id informado.
        public async Task<Message> GetByIdAnythingAsync(Message Message) {
            var result = await SearchByIdAsync("messages", Message.Id);
            return FromDynamicTo<Message>(result?.message);
        }

        //Retorna todas as notificações.
        public async Task<IEnumerable<Notification>> GetByAnythingAsync(Notification Notification, IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("notifications", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Notification>>(list?.notifications);
        }

        //Retorna uma notificação pelo id informado.
        public async Task<Notification> GetByIdAnythingAsync(Notification Notification) {
            var result = await SearchByIdAsync("notifications", Notification.Id);
            return FromDynamicTo<Notification>(result?.notification);
        }

        //Retorna todos os perfis de acesso
        public async Task<IEnumerable<Role>> GetByAnythingAsync(Role Role, IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("roles", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Role>>(list?.roles);
        }

        //Retorna o perfil de acesso pelo id informado.
        public async Task<Role> GetByIdAnythingAsync(Role Role) {
            var result = await SearchByIdAsync("roles", Role.Id);
            return FromDynamicTo<Role>(result?.role);
        }

        #endregion

        #region Post Methods

        //Cadastra o periodo de um plano passando sua entidade (Period)
        public async Task<Period> CreateAnythingAsync(Period NewPeriod) {
            var result = await PostByAnythingAsync("periods", NewPeriod);
            return FromDynamicTo<Period>(result?.period);
        }

        //Cadastra um perfil de pagamento de um cliente passando sua entidade (PaymentProfile)
        public async Task<PaymentProfile> CreateAnythingAsync(PaymentProfile NewPaymentProfile) {
            var result = await PostByAnythingAsync("payment_profiles", NewPaymentProfile);
            return FromDynamicTo<PaymentProfile>(result?.payment_profile);
        }

        public async Task<PaymentProfile> CreateDynamicAnythingAsync(PaymentProfile NewPaymentProfile) {
            dynamic Payload = NewPaymentProfile;
            var result = await PostByAnythingAsync("payment_profiles", Payload);
            return FromDynamicTo<PaymentProfile>(result?.payment_profile);
        }

        //Cadastra um plano passando sua entidade (Plan)
        public async Task<Plan> CreateAnythingAsync(CreatePlanRequester NewPlan) {
            var result = await PostByAnythingAsync("plans", NewPlan);
            return FromDynamicTo<Plan>(result?.plan);
        }

        //Cadastra o produto do item do plano passando sua entidade (Product)
        public async Task<Product> CreateAnythingAsync(Product NewProduct) {
            var result = await PostByAnythingAsync("products", NewProduct);
            return FromDynamicTo<Product>(result?.product);
        }

        //Cadastra um cliente passando sua entidade (Customer).
        public async Task<Customer> CreateAnythingAsync(Customer NewCustomer) {
            var result = await PostByAnythingAsync("customers", NewCustomer);
            return FromDynamicTo<Customer>(result?.customer);
        }

        //Cadastra um cliente dinamicamente passando sua entidade(Customer).
        public async Task<Customer> CreateDynamicAnythingAsync(Customer NewCustomer) {
            dynamic Payload = NewCustomer;
            var result = await PostByAnythingAsync("customers", Payload);
            return FromDynamicTo<Customer>(result?.customer);
        }

        //Faz a requisição de cadastro da assinatura e retorna a assinatura passando a entidade(SubscriptionRequester) 
        public async Task<Subscription> CreateAnythingAsync(SubscriptionRequester NewSubscriptionRequester) {
            var result = await PostByAnythingAsync("subscriptions", NewSubscriptionRequester);
            return FromDynamicTo<Subscription>(result?.subscription);
        }

        //Faz a requisição de cadastro da assinatura dinamicamente e retorna a assinatura passando a entidade(SubscriptionRequester) 
        public async Task<Subscription> CreateDynamicAnythingAsync(Subscription NewSubscription) {
            dynamic Payload = NewSubscription;
            var result = await PostByAnythingAsync("subscriptions", Payload);
            return FromDynamicTo<Subscription>(result?.subscription);
        }

        #endregion

        #region Put Methods

        //Atualiza um cliente passando sua entidade(Customer) com os dados a serem atualizados.
        public async Task<Customer> UpdateAnythingAsync(Customer CustomerEdit) {
            dynamic Payload = CustomerEdit;
            var result = await PutByIdAsync("customers", CustomerEdit.Id, Payload);
            return FromDynamicTo<Customer>(result?.customer);
        }

        //Atualiza um produto passando sua entidade(Product) com os dados a serem atualizados.
        public async Task<Product> UpdateAnythingAsync(Product ProductEdit) {
            dynamic Payload = ProductEdit;
            var result = await PutByIdAsync("products", ProductEdit.Id, Payload);
            return FromDynamicTo<Product>(result?.product);
        }

        //Atualiza um plano passando sua entidade(Plan) com os dados a serem atualizados.
        public async Task<Plan> UpdateAnythingAsync(Plan PlanEdit) {
            dynamic Payload = PlanEdit;
            var result = await PutByIdAsync("plans", PlanEdit.Id, Payload);
            return FromDynamicTo<Plan>(result?.plan);
        }

        //Atualiza uma assinatura passando sua entidadade(Subscription) com os dados a serem atualizados.
        public async Task<Subscription> UpdateAnythingAsync(Subscription SubscriptionEdit) {
            object Payload = SubscriptionEdit;
            var result = await PutByIdAsync("subscriptions", SubscriptionEdit.Id, Payload);
            return FromDynamicTo<Subscription>(result?.subscription);
        }

        //Atualiza uma assinatura passando sua entidadade(Bill) com os dados a serem atualizados.
        public async Task<Bill> UpdateAnythingAsync(Bill BillEdit) {
            object Payload = BillEdit;
            var result = await PutByIdAsync("bills", BillEdit.Id, Payload);
            return FromDynamicTo<Bill>(result?.bill);
        }

        //Atualiza uma cobrança passando sua entidadade(charge) com os dados a serem atualizados.
        public async Task<Bill> UpdateAnythingAsync(Charge ChargeEdit) {
            object Payload = ChargeEdit;
            var result = await PutByIdAsync("charges", ChargeEdit.Id, Payload);
            return FromDynamicTo<Bill>(result?.charge);
        }
        //Atualiza uma cobrança passando sua entidadade(charge) com os dados a serem atualizados.
        public async Task<Bill> UpdateAnythingAsync(Transaction TransactionEdit) {
            object Payload = TransactionEdit;
            var result = await PutByIdAsync("transactions", TransactionEdit.Id, Payload);
            return FromDynamicTo<Bill>(result?.transaction);
        }


        #endregion

        #region Delete Methods

        //Deleta o Cliente pelo id informado.
        public async Task<Customer> DeleteAnythingAsync(Customer DeleteCustomer) {
            var result = await DeleteByIdAsync("customers", DeleteCustomer.Id);
            return FromDynamicTo<Customer>(result?.customer);
        }

        //Deleta o perfil de pagamento pelo id informado.
        public async Task<PaymentProfile> DeleteAnythingAsync(PaymentProfile DeletePaymentProfile) {
            var result = await DeleteByIdAsync("payment_profiles", DeletePaymentProfile.Id);
            return FromDynamicTo<PaymentProfile>(result?.payment_profile);
        }

        //Deleta o plano pelo id informado.
        public async Task<Plan> DeleteAnythingAsync(Plan Plan) {
            var result = await DeleteByIdAsync("plans", Plan.Id);
            return FromDynamicTo<Plan>(result?.plan);
        }

        //Deleta a assinatura pelo id informado.
        public async Task<Subscription> DeleteAnythingAsync(Subscription DeleteSubscription, IDictionary<FilterSearch, String> Query = null) {
            var result = await DeleteByIdAndQueryAsync("subscriptions", DeleteSubscription.Id, Query);
            return FromDynamicTo<Subscription>(result?.subscription);
        }

        #endregion
    }
}
