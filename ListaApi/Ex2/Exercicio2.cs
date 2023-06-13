using ListaApi.Ex1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaApi.Ex2
{
    public class Exercicio2
    {

        public void Menu()
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1. Buscar por moeda");
                Console.WriteLine("2. Buscar por continente");
                Console.WriteLine("3. Sair");

                string opcao = Console.ReadLine();
                string url = "";

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("Digite a moeda que deseja buscar");
                        string moeda = Console.ReadLine();
                        url = $"https://restcountries.com/v3.1/currency/{moeda}?fields=name,capital,currencies";
                        GetCountry(url);
                        break;
                    case "2":
                        Console.WriteLine("Digite o continente que deseja buscar");
                        string continente = Console.ReadLine();
                        url = $"https://restcountries.com/v3.1/currency/{continente}?fields=name,capital,currencies";
                        GetCountry(url);
                        break;
                    case "3":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, selecione novamente.");
                        break;
                }

                Console.WriteLine();
            }
        }
        public async void GetCountry(string url)
        {
            HttpClient httpClient = new HttpClient();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    Country data = Newtonsoft.Json.JsonConvert.DeserializeObject<Country>(responseBody);

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
