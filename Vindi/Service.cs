using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vindi.Requesters;

namespace Vindi
{
    class Service
    {
        #region Atributes

        private object Authorization;
        private string UrlApi;

        #endregion

        #region Constructor

        public Service(Configuration Config) {
            this.UrlApi = $@"{Config.UrlApi}/api/v{Config.Version}";
            this.Authorization = Config.Authorization;
        }

        #endregion

        #region Others

        private async Task<dynamic> DeleteByIdAndQueryAsync(string uri, int id, IDictionary<FilterSearch, string> query = null) {
            var queryString = QueryString(query);
            return await $@"{UrlApi}/{uri}/{id}{(string.IsNullOrEmpty(queryString) ? string.Empty : queryString.Substring(1))}"
                .WithBasicAuth(Convert.ToString(Authorization), "").AllowAnyHttpStatus()
                .DeleteAsync()
                .ReceiveJson();
        }
        private async Task<dynamic> DeleteByIdAsync(string uri, int id)
            => await $@"{UrlApi}/{uri}/{id}"
                .WithBasicAuth(Convert.ToString(Authorization), "").AllowAnyHttpStatus()
                .DeleteAsync()
                .ReceiveJson();

        private async Task<dynamic> PostByAnythingBodyAsync(string uri, string param, string action)
            => await $@"{UrlApi}/{uri}/{param}/{action}"
                .WithBasicAuth(Convert.ToString(Authorization), "")
                .PostAsync(null)
                .ReceiveJson();

        private async Task<dynamic> PostByAnythingAsync(string uri, object requster)
            => await $@"{UrlApi}/{uri}"
                .WithBasicAuth(Convert.ToString(Authorization), "")
                .PostJsonAsync(requster)
                .ReceiveJson();

        private async Task<dynamic> PutByAnythingAsync(string uri, object requster)
            => await $@"{UrlApi}/{uri}"
                .WithBasicAuth(Convert.ToString(Authorization), "")
                .PutJsonAsync(requster)
                .ReceiveJson();

        private async Task<dynamic> PutByIdAsync(string uri, int id, object requester)
            => await $@"{UrlApi}/{uri}/{id}"
                .WithBasicAuth(Convert.ToString(Authorization), "")
                .PutJsonAsync(requester).ReceiveJson();
        
        private static T FromDynamicTo<T>(dynamic d) where T : class {
            var p = JsonConvert.SerializeObject(d);
            if (p.StartsWith("["))
                return JArray.Parse(p).ToObject<T>();
            return JObject.Parse(p).ToObject<T>();
        }

        private static string QueryString(IDictionary<FilterSearch, string> query)
            => query != null ? $"&query={string.Join(" ", query.Select(x => $"{x.Key.ToString()}:{x.Value}"))}" : string.Empty;
        private async Task<dynamic> SearchByAnythingAsync(string uri, IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc)
            => await $@"{UrlApi}/{uri}?page={page}&per_page={perPage}&sort_by={filterSearch.ToString()}&sort_order={sortOrder.ToString()}{QueryString(query)}"
                .WithBasicAuth(Convert.ToString(Authorization), "")
                .GetJsonAsync();

        private async Task<dynamic> SearchByIdAsync(string uri, int id)
            => await $@"{UrlApi}/{uri}/{id}"
                .WithBasicAuth(Convert.ToString(Authorization), "")
                .GetJsonAsync();

        #endregion

        #region Get Methods

        //Retorna todos os produtos
        public async Task<IEnumerable<Product>> GetByAnythingAsync(Product Product ,IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("products", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Product>>(list?.products);
        }

        //Retorna o produto pelo id informado
        public async Task<Product> GetByIdAnythingAsync(Product Product, Int32 Id) {
            var result = await SearchByIdAsync("products", Id);
            return FromDynamicTo<Product>(result?.product);
        }

        //Retorna o item do produto pelo id informado
        public async Task<Product_Items> GetByIdAnythingAsync(Product_Items ProductItems, Int32 Id) {
            var result = await SearchByIdAsync("product_items", Id);
            return FromDynamicTo<Product_Items>(result?.product_item);
        }

        //Retorna todos os Planos
        public async Task<IEnumerable<Plan>> GetByAnythingAsync(Plan Plan, IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("plans", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Plan>>(list?.plans);
        }

        //Retorna o plano pelo id informado
        public async Task<Plan> GetByIdAnythingAsync(Plan Plan ,Int32 Id) {
            var result = await SearchByIdAsync("plans", Id);
            return FromDynamicTo<Plan>(result?.plan);
        }

        //Retorna todos os clientes
        public async Task<IEnumerable<Customer>> GetByAnythingAsync(Customer Customer,IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("customers", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Customer>>(list?.customers);
        }

        //Retorna o cliente pelo id informado
        public async Task<Customer> GetByIdAnythingAsync(Customer Customer, Int32 Id) {
            var result = await SearchByIdAsync("customers", Id);
            return FromDynamicTo<Customer>(result?.customer);
        }

        //Retorna todas as assinaturas
        public async Task<IEnumerable<Subscription>> GetByAnythingAsync(Subscription Subscription,IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("subscriptions", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Subscription>>(list?.subscriptions);
        }

        //Retorna a assinatura pelo id informado
        public async Task<Subscription> GetByIdAnythingAsync(Subscription Subscription ,Int32 Id) {
            var result = await SearchByIdAsync("subscriptions", Id);
            return FromDynamicTo<Subscription>(result?.subscription);
        }

        //Retorna todos os periodos
        public async Task<IEnumerable<Period>> GetByAnythingAsync(Period Period, IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("periods", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Period>>(list?.periods);
        }

        //Retorna o periodo pelo id informado
        public async Task<Period> GetByIdAnythingAsync(Period Period ,Int32 Id) {
            var result = await SearchByIdAsync("periods", Id);
            return FromDynamicTo<Period>(result?.period);
        }

        //Retorna todos os metodos de Pagamento
        public async Task<IEnumerable<Payment_Methods>> GetByAnythingAsync(Payment_Methods PaymentMethods,IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("payment_methods", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Payment_Methods>>(list?.payment_methods);
        }

        //Retorna o metodo de Pagamento pelo id informado
        public async Task<Payment_Methods> GetByIdAnythingAsync(Payment_Methods PaymentMethods, Int32 Id) {
            var result = await SearchByIdAsync("payment_methods", Id);
            return FromDynamicTo<Payment_Methods>(result?.payment_method);
        }

        //Retorna todos os perfis de pagamento
        public async Task<IEnumerable<Payment_Profile>> GetByAnythingAsync( Payment_Profile PaymentProfile,IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("payment_profiles", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Payment_Profile>>(list?.payment_profiles);
        }

        //Retorna o perfil de pagamento pelo id informado
        public async Task<Payment_Profile> GetByIdAnythingAsync(Payment_Profile PaymentProfile, Int32 Id) {
            var result = await SearchByIdAsync("payment_profiles", Id);
            return FromDynamicTo<Payment_Profile>(result?.payment_profile);
        }

        //Retorna todas as cobranças
        public async Task<IEnumerable<Charge>> GetByAnythingAsync(Charge Charge,IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.created_at, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("charges", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Charge>>(list?.charges);
        }

        //Retorna a cobranças pelo id informado
        public async Task<Charge> GetByIdAnythingAsync(Charge Charge, Int32 Id) {
            var result = await SearchByIdAsync("charges", Id);
            return FromDynamicTo<Charge>(result?.charge);
        }

        //Retorna todas as faturas
        public async Task<IEnumerable<Bill>> GetByAnythingAsync(Bill Bill, IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("bills", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Bill>>(list?.bills);
        }

        //Retorna a faturas pelo id informado
        public async Task<Bill> GetByIdAnythingAsync(Bill Bill, Int32 Id) {
            var result = await SearchByIdAsync("bills", Id);
            return FromDynamicTo<Bill>(result?.bill);
        }

        //Retorna o item da fatura pelo id do item informado
        public async Task<Bill_Items> GetByIdAnythingAsync(Bill_Items Bill_Items,Int32 Id) {
            var result = await SearchByIdAsync("bill_items", Id);
            return FromDynamicTo<Bill_Items>(result?.bill_item);
        }

        //Retorna o Desconto pelo id informado.
        public async Task<Discount> GetByIdAnythingAsync(Discount Discount, Int32 Id) {
            var result = await SearchByIdAsync("discounts", Id);
            return FromDynamicTo<Discount>(result?.discount);
        }

        //Retorna todos os lotes de importação.
        public async Task<IEnumerable<Import_Batche>> GetByAnythingAsync(Import_Batche ImportBatche ,IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("import_batches", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Import_Batche>>(list?.import_batches);
        }

        //Retorna o lote de importação pelo id informado.
        public async Task<Import_Batche> GetByIdAnythingAsync(Import_Batche ImportBatche, Int32 Id) {
            var result = await SearchByIdAsync("import_batches", Id);
            return FromDynamicTo<Import_Batche>(result?.import_batche);
        }

        //Retorna todas as notas fiscais.
        public async Task<IEnumerable<Invoice>> GetByAnythingAsync(Invoice Invoice ,IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("invoices", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Invoice>>(list?.invoices);
        }

        //Retorna a nota fiscal pelo id informado.
        public async Task<Invoice> GetByIdAnythingAsync(Invoice Invoice, Int32 Id) {
            var result = await SearchByIdAsync("invoices", Id);
            return FromDynamicTo<Invoice>(result?.invoice);
        }

        //Retorna todas as pendencias.
        public async Task<IEnumerable<Issue>> GetByAnythingAsync(Issue Issue,IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("issues", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Issue>>(list?.issues);
        }

        //Retorna uma pedencia pelo id informado.
        public async Task<Issue> GetByIdAnythingAsync(Issue Issue, Int32 Id) {
            var result = await SearchByIdAsync("issues", Id);
            return FromDynamicTo<Issue>(result?.issue);
        }

        //Retorna todas as empresas cadastradas
        public async Task<IEnumerable<Merchant>> GetByAnythingAsync(Merchant Merchant, IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("merchants", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Merchant>>(list?.merchants);
        }

        //Retorna a empresa cadastrada pelo id informado
        public async Task<Merchant> GetByIdAnythingAsync(Merchant Merchant, Int32 Id) {
            var result = await SearchByIdAsync("merchants", Id);
            return FromDynamicTo<Merchant>(result?.merchant);
        }

        //Retorna todos os usuarios associados cadastrados.
        public async Task<IEnumerable<Merchant_Users>> GetByAnythingAsync(Merchant_Users MerchantUsers ,IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("merchant_users", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Merchant_Users>>(list?.merchant_users);
        }

        //Retorna os usuarios associados pelo id informado.
        public async Task<Merchant_Users> GetByIdAnythingAsync(Merchant_Users MerchantUsers ,Int32 Id) {
            var result = await SearchByIdAsync("merchant_users", Id);
            return FromDynamicTo<Merchant_Users>(result?.merchant_user);
        }

        //Retorna todas as mensagens.
        public async Task<IEnumerable<Message>> GetByAnythingAsync(Message Message ,IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("messages", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Message>>(list?.messages);
        }

        //Retorna um mensagem pelo id informado.
        public async Task<Message> GetByIdAnythingAsync(Message Message,Int32 Id) {
            var result = await SearchByIdAsync("messages", Id);
            return FromDynamicTo<Message>(result?.message);
        }

        //Retorna todas as notificações.
        public async Task<IEnumerable<Notification>> GetByAnythingAsync(Notification Notification ,IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("notifications", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Notification>>(list?.notifications);
        }

        //Retorna uma notificação pelo id informado.
        public async Task<Notification> GetByIdAnythingAsync(Notification Notification ,Int32 Id) {
            var result = await SearchByIdAsync("notifications", Id);
            return FromDynamicTo<Notification>(result?.notification);
        }

        //Retorna todos os perfis de acesso
        public async Task<IEnumerable<Role>> GetByAnythingAsync(Role Role ,IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("roles", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Role>>(list?.roles);
        }

        //Retorna o perfil de acesso pelo id informado.
        public async Task<Role> GetByIdAnythingAsync(Role Role ,Int32 Id) {
            var result = await SearchByIdAsync("roles", Id);
            return FromDynamicTo<Role>(result?.role);
        }

        #endregion

        #region Post Methods

        //Cadastra um cliente passando sua entidade (Customer).
        public async Task<Customer> CreateAnythingAsync(Customer Customer) {
            var result = await PostByAnythingAsync("customers", Customer);
            return FromDynamicTo<Customer>(result?.customer);
        }

        //Cadastra um cliente dinamicamente passando sua entidade(Customer).
        public async Task<Customer> CreateDynamicAnythingAsync(Customer Customer, dynamic Payload) {
            var result = await PostByAnythingAsync("customers", Payload);
            return FromDynamicTo<Customer>(result?.customer);
        }

        //Faz a requisição de cadastro da assinatura e retorna a assinatura passando a entidade(SubscriptionRequester) 
        public async Task<Subscription> CreateAnythingAsync(SubscriptionRequester SubscriptionRequester) {
            var result = await PostByAnythingAsync("subscriptions", SubscriptionRequester);
            return FromDynamicTo<Subscription>(result?.subscription);
        }

        //Faz a requisição de cadastro da assinatura dinamicamente e retorna a assinatura passando a entidade(SubscriptionRequester) 
        public async Task<Subscription> CreateDynamicAnythingAsync(Subscription Subscription, dynamic Payload) {
            var result = await PostByAnythingAsync("subscriptions", Payload);
            return FromDynamicTo<Subscription>(result?.subscription);
        }

        #endregion

        #region Put Methods
        //Atualiza um cliente passando seu id e sua entidade(Customer) com os dados a serem atualizados.
        public async Task<Customer> UpdateAnythingAsync(Customer Customer, Int32 Id, dynamic Payload) {
            var result = await PutByIdAsync("customers", Id, Payload);
            return FromDynamicTo<Customer>(result?.customer);
        }

        //Atualiza uma assinatura passando seu id e sua entidadade(Subscription) convertida para object com os dados a serem atualizados.
        public async Task<Subscription> UpdateAnythingAsync(Subscription Subscription, Int32 Id, object Payload) {
            var result = await PutByIdAsync("subscriptions", Id, Payload);
            return FromDynamicTo<Subscription>(result?.subscription);
        }


        #endregion

        #region Delete Methods

        //Deleta o Cliente pelo id informado.
        public async Task<Customer> DeleteAnythingAsync(Customer Customer,Int32 Id) {
            var result = await DeleteByIdAsync("customers", Id);
            return FromDynamicTo<Customer>(result?.customer);
        }

        //Deleta a assinatura pelo id informado.
        public async Task<Subscription> DeleteAnythingAsync(Subscription Subscription, int id, IDictionary<FilterSearch, string> query = null) {
            var result = await DeleteByIdAndQueryAsync("subscriptions", id, query);
            return FromDynamicTo<Subscription>(result?.subscription);
        }

        #endregion
    }
}
