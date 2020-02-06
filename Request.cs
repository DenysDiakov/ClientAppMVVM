using ClientAppMVVM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientAppMVVM
{
    class Request
    {
        public static async Task<ObservableCollection<Product>> SendGetRequest()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44395/");
            HttpResponseMessage response = await client.GetAsync("api/values");

            var json = await response.Content.ReadAsStringAsync();

            var productsList = JsonConvert.DeserializeObject<ObservableCollection<Product>>(json);

            return productsList;
        }

        public static async Task SendPostRequest(Product selectedProduct)
        {
            var serializebleProduct = new Product();
            serializebleProduct.Name = $"{selectedProduct.Name}";
            serializebleProduct.Price = int.Parse($"{selectedProduct.Price}");

            var json = JsonConvert.SerializeObject(serializebleProduct);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:44395/api/cart";

            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);
        }


        public static async Task<ObservableCollection<Product>> SendGetRequestToCart()
        {
            var getClient = new HttpClient();
            getClient.BaseAddress = new Uri("https://localhost:44395/");
            HttpResponseMessage getResponse = await getClient.GetAsync("api/cart");

            var json2 = await getResponse.Content.ReadAsStringAsync();

            var productsList = JsonConvert.DeserializeObject<ObservableCollection<Product>>(json2);

            return productsList;
        }


        public static void DeleteRequest(Product selectedProduct)
        {
            string sURL = $"https://localhost:44395/api/cart/{selectedProduct.Id}";

            WebRequest request = WebRequest.Create(sURL);
            request.Method = "DELETE";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        }



    }
}
