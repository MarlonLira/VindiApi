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

        private Object Authorization;
        private String UrlApi;

        #endregion

        #region Constructor

        public Service(Configuration Config) {
            this.UrlApi = $@"{Config.UrlApi}/api/v{Config.Version}";
            this.Authorization = Config.Authorization;
        }

        #endregion

        #region Others

        private async Task<dynamic> DeleteByIdAndQueryAsync(String Uri, Int32 Id, IDictionary<FilterSearch, String> Query = null) {
            var queryString = QueryString(Query);
            return await $@"{UrlApi}/{Uri}/{Id}{(String.IsNullOrEmpty(queryString) ? String.Empty : queryString.Substring(1))}"
                .WithBasicAuth(Convert.ToString(Authorization), "").AllowAnyHttpStatus()
                .DeleteAsync()
                .ReceiveJson();
        }
        private async Task<dynamic> DeleteByIdAsync(String Uri, Int32 Id)
            => await $@"{UrlApi}/{Uri}/{Id}"
                .WithBasicAuth(Convert.ToString(Authorization), "").AllowAnyHttpStatus()
                .DeleteAsync()
                .ReceiveJson();

        private async Task<dynamic> PostByAnythingBodyAsync(String Uri, String Param, String Action)
            => await $@"{UrlApi}/{Uri}/{Param}/{Action}"
                .WithBasicAuth(Convert.ToString(Authorization), "")
                .PostAsync(null)
                .ReceiveJson();

        private async Task<dynamic> PostByAnythingAsync(String Uri, Object Requster)
            => await $@"{UrlApi}/{Uri}"
                .WithBasicAuth(Convert.ToString(Authorization), "")
                .PostJsonAsync(Requster)
                .ReceiveJson();

        private async Task<dynamic> PutByAnythingAsync(String Uri, Object Requster)
            => await $@"{UrlApi}/{Uri}"
                .WithBasicAuth(Convert.ToString(Authorization), "")
                .PutJsonAsync(Requster)
                .ReceiveJson();

        private async Task<dynamic> PutByIdAsync(String Uri, Int32 Id, Object Requester)
            => await $@"{UrlApi}/{Uri}/{Id}"
                .WithBasicAuth(Convert.ToString(Authorization), "")
                .PutJsonAsync(Requester).ReceiveJson();
        
        private static T FromDynamicTo<T>(dynamic d) where T : class {
            var p = JsonConvert.SerializeObject(d);
            if (p.StartsWith("["))
                return JArray.Parse(p).ToObject<T>();
            return JObject.Parse(p).ToObject<T>();
        }

        private static string QueryString(IDictionary<FilterSearch, String> Query)
            => Query != null ? $"&query={String.Join(" ", Query.Select(x => $"{x.Key.ToString()}:{x.Value}"))}" : String.Empty;

        private async Task<dynamic> SearchByAnythingAsync(String Uri, IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc)
            => await $@"{UrlApi}/{Uri}?Page={Page}&per_Page={PerPage}&sort_by={filterSearch.ToString()}&sort_order={sortOrder.ToString()}{QueryString(Query)}"
                .WithBasicAuth(Convert.ToString(Authorization), "")
                .GetJsonAsync();

        private async Task<dynamic> SearchByIdAsync(String Uri, Int32 Id)
            => await $@"{UrlApi}/{Uri}/{Id}"
                .WithBasicAuth(Convert.ToString(Authorization), "")
                .GetJsonAsync();

        #endregion

        #region Get Methods

        //Retorna todos os produtos
        public async Task<IEnumerable<Product>> GetByAnythingAsync(Product Product ,IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
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

        //Retorna todos os clientes
        public async Task<IEnumerable<Customer>> GetByAnythingAsync(Customer Customer,IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("customers", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Customer>>(list?.customers);
        }

        //Retorna o cliente pelo id informado
        public async Task<Customer> GetByIdAnythingAsync(Customer Customer) {
            var result = await SearchByIdAsync("customers", Customer.Id);
            return FromDynamicTo<Customer>(result?.customer);
        }

        //Retorna todas as assinaturas
        public async Task<IEnumerable<Subscription>> GetByAnythingAsync(Subscription Subscription,IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("subscriptions", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Subscription>>(list?.subscriptions);
        }

        //Retorna a assinatura pelo id informado
        public async Task<Subscription> GetByIdAnythingAsync(Subscription Subscription) {
            var result = await SearchByIdAsync("subscriptions", Subscription.Id);
            return FromDynamicTo<Subscription>(result?.subscription);
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
        public async Task<IEnumerable<PaymentMethods>> GetByAnythingAsync(PaymentMethods PaymentMethods,IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("payment_methods", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<PaymentMethods>>(list?.payment_methods);
        }

        //Retorna o metodo de Pagamento pelo id informado
        public async Task<PaymentMethods> GetByIdAnythingAsync(PaymentMethods PaymentMethods) {
            var result = await SearchByIdAsync("payment_methods", PaymentMethods.Id);
            return FromDynamicTo<PaymentMethods>(result?.payment_method);
        }

        //Retorna todos os perfis de pagamento
        public async Task<IEnumerable<PaymentProfile>> GetByAnythingAsync(PaymentProfile PaymentProfile,IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("payment_profiles", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<PaymentProfile>>(list?.payment_profiles);
        }

        //Retorna o perfil de pagamento pelo id informado
        public async Task<PaymentProfile> GetByIdAnythingAsync(PaymentProfile PaymentProfile) {
            var result = await SearchByIdAsync("payment_profiles", PaymentProfile.Id);
            return FromDynamicTo<PaymentProfile>(result?.payment_profile);
        }

        //Retorna todas as cobranças
        public async Task<IEnumerable<Charge>> GetByAnythingAsync(Charge Charge,IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.created_at, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("charges", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Charge>>(list?.charges);
        }

        //Retorna a cobranças pelo id informado
        public async Task<Charge> GetByIdAnythingAsync(Charge Charge) {
            var result = await SearchByIdAsync("charges", Charge.Id);
            return FromDynamicTo<Charge>(result?.charge);
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
        public async Task<IEnumerable<Issue>> GetByAnythingAsync(Issue Issue,IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
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
        public async Task<IEnumerable<Notification>> GetByAnythingAsync(Notification Notification ,IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("notifications", Query, Page, PerPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Notification>>(list?.notifications);
        }

        //Retorna uma notificação pelo id informado.
        public async Task<Notification> GetByIdAnythingAsync(Notification Notification) {
            var result = await SearchByIdAsync("notifications", Notification.Id);
            return FromDynamicTo<Notification>(result?.notification);
        }

        //Retorna todos os perfis de acesso
        public async Task<IEnumerable<Role>> GetByAnythingAsync(Role Role ,IDictionary<FilterSearch, String> Query = null, Int32 Page = 1, Int32 PerPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
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
        public async Task<Customer> UpdateAnythingAsync(Customer CustomerEdit){
            dynamic Payload = CustomerEdit;
            var result = await PutByIdAsync("customers", CustomerEdit.Id, Payload);
            return FromDynamicTo<Customer>(result?.customer);
        }

        //Atualiza uma assinatura passando sua entidadade(Subscription) com os dados a serem atualizados.
        public async Task<Subscription> UpdateAnythingAsync(Subscription SubscriptionEdit) {
            object Payload = SubscriptionEdit;
            var result = await PutByIdAsync("subscriptions", SubscriptionEdit.Id, Payload);
            return FromDynamicTo<Subscription>(result?.subscription);
        }


        #endregion

        #region Delete Methods

        //Deleta o Cliente pelo id informado.
        public async Task<Customer> DeleteAnythingAsync(Customer DeleteCustomer) {
            var result = await DeleteByIdAsync("customers", DeleteCustomer.Id);
            return FromDynamicTo<Customer>(result?.customer);
        }

        //Deleta a assinatura pelo id informado.
        public async Task<Subscription> DeleteAnythingAsync(Subscription DeleteSubscription, IDictionary<FilterSearch, String> Query = null) {
            var result = await DeleteByIdAndQueryAsync("subscriptions", DeleteSubscription.Id, Query);
            return FromDynamicTo<Subscription>(result?.subscription);
        }

        #endregion
    }
}
