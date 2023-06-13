using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaApi.Ex3
{
    public class Exercicio3
    {
        private const string ApiUrl = "https://economia.awesomeapi.com.br/json/last/{0}-{1}";

        public async Task<decimal> ConverterMoedas(string moeda1, string moeda2, decimal amount)
        {
            string url = string.Format(ApiUrl, moeda1, moeda2);

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string json = await response.Content.ReadAsStringAsync();

                    dynamic responseObject = JsonConvert.DeserializeObject(json);
                    decimal exchangeRate = responseObject[moeda1 + moeda2].ask;

                    return amount * exchangeRate;
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine("Error occurred while accessing the API: " + ex.Message);
                    return 0;
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("Error occurred while parsing the API response: " + ex.Message);
                    return 0;
                }
            }
        }
    }
}
