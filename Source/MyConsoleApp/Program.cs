using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace MyConsoleApp
{
        
    class Program
    {
       static async Task Main(string[] args)
        {
            StarshipResponse starshipResponse = await new StarshipResponse().GetShips();
            PeopleResponse peopleResponse = await new PeopleResponse().GetPeople();

            foreach (var p in starshipResponse.Results)
            {
                Console.WriteLine(p.Name);
            }

            Console.ReadKey();
        }
    }

    
}
