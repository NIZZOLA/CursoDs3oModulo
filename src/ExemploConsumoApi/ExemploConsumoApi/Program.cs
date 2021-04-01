using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExemploConsumoApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            
            Executar().Wait();

        //    ObterCep().Wait();
        }

        static async Task Executar()
        {
            string url = "https://localhost:44380/api/contato2";
            try
            {
                using (var cliente = new HttpClient())
                {
                    var resultado = await cliente.GetStringAsync(url);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message.ToString() + " Chamando API:" + url);
                
            }
            
        }

        static async Task ObterCep()
        {
            using (var cliente = new HttpClient())
            {
                var resultado = await cliente.GetStringAsync("https://viacep.com.br/ws/13328301/json/");

                var retorno = JsonSerializer.Deserialize<LocalizacaoModel>(resultado);
            }
        }

    }
}
