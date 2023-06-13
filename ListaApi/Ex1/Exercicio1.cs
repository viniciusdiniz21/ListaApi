using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaApi.Ex1
{
    public class Exercicio1
    {
        public async void GetIpDetails()
        {
            HttpClient httpClient = new HttpClient();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("https://ipapi.co/json");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    Ip data = Newtonsoft.Json.JsonConvert.DeserializeObject<Ip>(responseBody);
                    Console.WriteLine($"ip: {data.ip}");
                    Console.WriteLine($"network: {data.network}");
                    Console.WriteLine($"version: {data.version}");
                    Console.WriteLine($"city: {data.city}");
                    Console.WriteLine($"region: {data.region}");
                }
                else
                {
                    Console.WriteLine($"Erro: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            Console.ReadLine();
        }
    }
}
