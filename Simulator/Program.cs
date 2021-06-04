using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Drawing;
using System.Threading;

namespace Simulator
{
    class Program
    {
      
        static async Task Main(string[] args)
        {
            Simulation sim = new Simulation();


            List<string> firstnames = new List<string>();
            firstnames.Add("John");
            firstnames.Add("James");
            firstnames.Add("Robert");
            firstnames.Add("Michael");
            firstnames.Add("William");
            firstnames.Add("David");
            firstnames.Add("Richard");
            firstnames.Add("Joseph");
            firstnames.Add("Thomas");
            firstnames.Add("Charles");
            firstnames.Add("Christopher");
            firstnames.Add("Daniel");
            firstnames.Add("Matthew");
            firstnames.Add("Anthony");
            firstnames.Add("Donald");

            List<string> lastnames = new List<string>();
            lastnames.Add("Smith");
            lastnames.Add("Johnson");
            lastnames.Add("Williams");
            lastnames.Add("Jones");
            lastnames.Add("Brown");
            lastnames.Add("Davis");
            lastnames.Add("Miller");
            lastnames.Add("Wilson");
            lastnames.Add("Moore");
            lastnames.Add("Taylor");
            lastnames.Add("Anderson");
            lastnames.Add("Thomas");
            lastnames.Add("Jackson");
            lastnames.Add("White");
            lastnames.Add("Harris");

            while (!Console.KeyAvailable)
            {
                var tasks = new List<Task>();
                for (int i = 0; i < 6; i++)
                {
                    Random rnd = new Random();
                    int income = rnd.Next(150000, 1500000);
                    int age = rnd.Next(18, 60);

                    string firstname = firstnames[rnd.Next(firstnames.Count)];
                    string lastname = lastnames[rnd.Next(lastnames.Count)];

                    var task = sim.CallFSAsync(firstname, lastname, income, age, i);
                    tasks.Add(task);
                    //await sim.CallFSAsync(firstname, lastname, income, age, i);
                }
                await Task.WhenAll(tasks);
            }
            Console.WriteLine("Simulation ended by the user (press ENTER to exit)...");
            Console.ReadLine();
        }
    }
}
