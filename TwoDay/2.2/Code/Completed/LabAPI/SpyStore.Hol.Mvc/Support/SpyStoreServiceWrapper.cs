using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SpyStore.Hol.Models.Entities;
using SpyStore.Hol.Models.Entities.Base;
using SpyStore.Hol.Models.ViewModels;

namespace SpyStore.Hol.Mvc.Support
{
    public interface ISpyStoreServiceWrapper
    {
        //CategoryController
        Task<IList<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
        Task<IList<Product>> GetProductsForACategoryAsync(int categoryId);
        ////Orders Controller
        //Task<IList<Order>> GetOrdersAsync(int customerId);
        //Task<OrderWithDetailsAndProductInfo> GetOrderDetailsAsync(int orderId);
        //Product Controller
        Task<Product> GetOneProductAsync(int productId);
        Task<IList<Product>> GetFeaturedProductsAsync();
        //Search Controller
        Task<IList<Product>> SearchAsync(string searchTerm);
        //Shopping Cart Record Controller
        Task<IList<CartRecordWithProductInfo>> GetCartRecordsAsync(int id);
        //Task<string> AddToCartAsync(int customerId, int productId, int quantity);
        Task<CartRecordWithProductInfo> UpdateShoppingCartRecord(int recordId, ShoppingCartRecord item);
        //Task RemoveCartItemAsync(ShoppingCartRecord item);
        //Shopping Cart Controller
        Task<CartWithCustomerInfo> GetCartAsync(int customerId);
        Task<string> PurchaseAsync(int customerId, Customer customer);
        //Customer Controller
        Task<Customer> GetCustomerAsync(int customerId);
        Task<IList<Customer>> GetCustomersAsync();
    }

    public class SpyStoreServiceWrapper : ISpyStoreServiceWrapper
    {
        private HttpClient _client;
        private ServiceSettings _settings;

        public SpyStoreServiceWrapper(HttpClient client, IOptionsSnapshot<ServiceSettings> settings)
        {
            _client = client;
            _settings = settings.Value;
            _client.BaseAddress = new Uri(_settings.Uri);
        }

        public async Task<IList<Category>> GetCategoriesAsync()
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.CategoryBaseUri}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<IList<Category>>();

            return result;
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.CategoryBaseUri}/{id}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<Category>();

            return result;
        }

        public async Task<IList<Product>> GetProductsForACategoryAsync(int categoryId)
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.CategoryBaseUri}/{categoryId}/products");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<IList<Product>>();

            return result;
        }

        public async Task<Product> GetOneProductAsync(int productId)
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.ProductBaseUri}/{productId}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<Product>();

            return result;
        }

        public async Task<IList<Product>> GetFeaturedProductsAsync()
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.ProductBaseUri}/featured");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<IList<Product>>();

            return result;
        }

        public async Task<IList<Product>> SearchAsync(string searchTerm)
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.SearchBaseUri}/{searchTerm}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<IList<Product>>();

            return result;
        }

        public async Task<IList<CartRecordWithProductInfo>> GetCartRecordsAsync(int id)
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.CartRecordBaseUri}/{id}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<IList<CartRecordWithProductInfo>>();

            return result;
        }

        public async Task<CartRecordWithProductInfo> UpdateShoppingCartRecord(int recordId, ShoppingCartRecord item)
        {
            var response = await _client.PutAsJsonAsync($"{_settings.Uri}{_settings.CartRecordBaseUri}/{recordId}", item);

            response.EnsureSuccessStatusCode();
            var location = response.Headers.Location.OriginalString;
            var updatedResponse = await _client.GetAsync(location);
            updatedResponse.EnsureSuccessStatusCode();
            var result = await updatedResponse.Content.ReadAsAsync<CartRecordWithProductInfo>();

            return result;
        }

        public async Task<CartWithCustomerInfo> GetCartAsync(int customerId)
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.CartBaseUri}/{customerId}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<CartWithCustomerInfo>();

            return result;
        }

        public async Task<string> PurchaseAsync(int customerId, Customer customer)
        {
            var response = await _client.PostAsJsonAsync($"{_settings.Uri}{_settings.CartBaseUri}/{customerId}",customer);

            response.EnsureSuccessStatusCode();
            
            var result = await response.Content.ReadAsAsync<Product>();
            //TODO: Fix this
            return null;
        }

        public async Task<Customer> GetCustomerAsync(int customerId)
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.CustomerBaseUri}/{customerId}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<Customer>();

            return null;
        }

        public async Task<IList<Customer>> GetCustomersAsync()
        {
            var response = await _client.GetAsync($"{_settings.Uri}{_settings.CustomerBaseUri}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<IList<Customer>>();

            return result;

        }
    }
}