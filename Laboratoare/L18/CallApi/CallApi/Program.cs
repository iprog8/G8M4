using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CallApi
{
    class Program
    {

        const string SERVER = "https://localhost:44399";
        const string CURRENCY = "/api/currency";
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(SERVER);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //apelare
            GetCurrencies(httpClient).Wait();
        }

        static async Task GetCurrencies(HttpClient httpClient)
        {
            using (httpClient)
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync(CURRENCY);
                responseMessage.EnsureSuccessStatusCode();
                if (responseMessage.IsSuccessStatusCode)
                {
                    string response = await responseMessage.Content.ReadAsStringAsync();
                    Console.ReadKey();
                }
            }
        }
    }
}
