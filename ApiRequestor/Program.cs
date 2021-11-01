using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ApiRequestor
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            var count = 1;
            using (var client = new HttpClient())
            {
                IoT ioT;
                while (count != 5000)
                {  
                    ioT = new IoT()
                    {
                        Id = count, Name = "Iot" + count, Temp = r.Next(10, 28)
                    };

                    client.BaseAddress = new Uri("https://localhost:44364/");
                    var response = client.PostAsJsonAsync("api/iot/IoTAdd", ioT).Result;
                    var data = response.Content;
                }

                //if (response.IsSuccessStatusCode)
                //{
                //    Task<string> d = data.ReadAsStringAsync();
                //    Console.Write(d.Result.ToString());
                //}
                Console.ReadLine();
            }
        }
    }
}
