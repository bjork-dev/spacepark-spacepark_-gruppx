using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;

namespace ClassLibrary
{
    public class Starship : IStarship
    {
        public List<ShipResult> Results { get; set; }

        public async Task<List<ShipResult>> GetStarships()
        {
            await using var context = new SpaceContext();
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("starships/", DataFormat.Json);
            var response = await client.GetAsync<Starship>(request);
            var parkedShips = context.Parkings.Where(p => p.Occupied).ToArray();

            for (int i = 0; i < parkedShips.Length; i++)
            {
                var name = parkedShips[i].User;
                if (response.Results.Any(n => n.Name == name))
                {
                    var index = response.Results.First(s => s.Name == name);
                    response.Results.Remove(index);
                }
            }
            return response.Results;
        }


        public IShipResult SelectShip()
        {
            IPerson person = new Person();
            string name = StandardMessages.NameReader();
            var apiResult = person.GetAllPersons();
            var shipResult = GetStarships();
            var array = ArrayBuilder.ShipArray(shipResult);

            if (apiResult.Result.Any(p => p.Name == name))
            {
                Console.Clear();
                var selectedOption = Menu.ShowMenu($"Welcome {name}. What ship will you be parking today?\n", array);
                shipResult.Result.Where((_, i) => selectedOption == i).First().Driver = name;
                return shipResult.Result.Where((_, i) => selectedOption == i).First();
            }
            StandardMessages.NotAllowedMessage();
            return null;
        }
    }
}