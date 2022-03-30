using Examen.MobileApp.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Examen.MobileApp.Models
{
    public class DataService : IDataService
    {
        private String sUrl = "https://c084-2806-2f0-2080-1421-bd48-47e9-32d2-a23.ngrok.io/v1/products";

        public String DeleteProduct(Int32 iID)
        {
            String content = String.Empty;

            try
            {
                var restClient = new RestClient(sUrl + $"{ iID }");
                var restRequest = new RestRequest(Method.DELETE);
                var response = restClient.Execute(restRequest);

                return response.Content;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return ex.Message;
            }
        }

        public Product GetProductById(Int32 iID)
        {
            String content = String.Empty;

            try
            {
                var restClient = new RestClient(sUrl + $"{ iID }");
                var restRequest = new RestRequest(Method.GET);
                var response = restClient.Execute(restRequest);

                return JsonConvert.DeserializeObject<Product>(response.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<ObservableCollection<Product>> GetProductsAsync()
        {
            ObservableCollection<Product> products = null;

            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(new Uri(sUrl));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<ObservableCollection<Product>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return products;
        }

        public Product InsertProduct(String sProductJson)
        {
            try
            {
                var restClient = new RestClient(sUrl);
                var restRequest = new RestRequest(Method.POST);

                restRequest.AddParameter("Content-type", "application/json");
                restRequest.AddParameter("application/json", sProductJson, ParameterType.RequestBody);
                restRequest.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

                var response = restClient.Execute(restRequest);

                return JsonConvert.DeserializeObject<Product>(response.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public String UpdateProduct(Int32 iID, String sProductJson)
        {
            String content = String.Empty;

            try
            {
                var restClient = new RestClient(sUrl + $"{ iID }");
                var restRequest = new RestRequest(Method.PUT);

                restRequest.AddParameter("Content-type", "application/json");
                restRequest.AddParameter("application/json", sProductJson, ParameterType.RequestBody);
                restRequest.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

                var response = restClient.Execute(restRequest);

                return response.Content;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return ex.Message;
            }
        }
    }
}
