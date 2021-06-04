using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Simulator
{
    class Simulation
    {
        public Simulation()
        {

        }
        public async Task CallFSAsync(string firstname, string lastname, int income, int age, int i)
        {
            Image image = Image.FromFile(@"Photos\bill_gates.jpg");
            using (var client = new HttpClient())
            {
                ImageConverter converter = new ImageConverter();
                FinancialStatement fs = new FinancialStatement { Firstname = firstname, Lastname = lastname, Income = income, Age = age, Photo = (byte[])converter.ConvertTo(image, typeof(byte[])) };
                var json = JsonConvert.SerializeObject(fs);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response;
                if(i%2 == 0)
                {
                    Console.WriteLine($"Worker app: request {i} sent");
                    response = await client.PostAsync("https://fswebapp2684263.azurewebsites.net/api/Statements/CreateStatement", data);
                    Console.WriteLine($"\tWorker app: HTTP status code {i}: {response.StatusCode}");
                }
                else
                {
                    Console.WriteLine($"Simple app: request {i} sent");
                    response = await client.PostAsync("https://fswebappsimple2684263.azurewebsites.net/api/Statements/CreateStatement", data);
                    Console.WriteLine($"\tSimple app: HTTP status code {i}: {response.StatusCode}");
                }
                //var response = await client.PostAsync("https://localhost:44341/api/Statements/CreateStatement", data);
            }
        }
    }
}
