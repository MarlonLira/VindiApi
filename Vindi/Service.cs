using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vindi
{
    class Service
    {

        private object Authorization;
        private string UrlApi;

        public Service(Configuration Config) {
            this.UrlApi = $@"{Config.UrlApi}/api/v{Config.Version}";
            this.Authorization = Config.Authorization;
        }

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

        #region Gets

        //Retorna todos os produtos
        public async Task<IEnumerable<Product>> GetProductsByAnythingAsync(Product Product ,IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("products", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Product>>(list?.products);
        }

        //Retorna todos os Planos
        public async Task<IEnumerable<Plan>> GetByAnythingAsync(Plan Plan, IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("plans", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Plan>>(list?.plans);
        }

        //Retorna todos os clientes
        public async Task<IEnumerable<Customer>> GetByAnythingAsync(Customer Customer,IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("customers", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Customer>>(list?.customers);
        }

        //Retorna todos os cadastros
        public async Task<IEnumerable<Subscription>> GetSubscriptionsByAnythingAsync(Subscription Subscription,IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("subscriptions", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Subscription>>(list?.subscriptions);
        }

        //Retorna todos os periodos
        public async Task<IEnumerable<Period>> GetByAnythingAsync(Period Period, IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("periods", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Period>>(list?.periods);
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
        public async Task<IEnumerable<Payment_Profile>> GetPaymentProfilesByAnythingAsync(IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("payment_profiles", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Payment_Profile>>(list?.payment_profiles);
        }

        //Retorna todas as cargas
        public async Task<IEnumerable<Charge>> GetByAnythingAsync(Charge Charge,IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.created_at, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("charges", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Charge>>(list?.charges);
        }

        //Retorna a carga pelo id informado
        public async Task<Charge> GetByIdAsync(Charge Charge, Int32 Id) {
            var result = await SearchByIdAsync("charges", Id);
            return FromDynamicTo<Charge>(result?.charge);
        }

        //Retorna todas as contas
        public async Task<IEnumerable<Bill>> GetByAnythingAsync(Bill Bill, IDictionary<FilterSearch, string> query = null, int page = 1, int perPage = 20, FilterSearch filterSearch = FilterSearch.id, SortOrder sortOrder = SortOrder.asc) {
            var list = await SearchByAnythingAsync("bills", query, page, perPage, filterSearch, sortOrder);
            return FromDynamicTo<IEnumerable<Bill>>(list?.bills);
        }
        
        //Retorna a conta pelo id informado
        public async Task<Bill> GetByIdAsync(Bill Bill, Int32 Id) {
            var result = await SearchByIdAsync("bills", Id);
            return FromDynamicTo<Bill>(result?.bill);
        }

        //Retorna o item da conta pelo id informado
        public async Task<Bill_Items> GetByIdAsync(Bill_Items Bill_Items,Int32 Id) {
            var result = await SearchByIdAsync("bill_items", Id);
            return FromDynamicTo<Bill_Items>(result?.bill_item);
        }
        #endregion
    }
}
