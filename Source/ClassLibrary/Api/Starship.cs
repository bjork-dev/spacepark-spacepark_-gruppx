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
        public string Count {get;set;}
        public string Previous { get; set; }
        public string Next { get; set; }

        public async Task<Starship> GetStarshipsOnePage(int page)
        {
            await using var context = new SpaceContext();
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest($"starships/?page={page}", DataFormat.Json);
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
            return response;
        }

        public IShipResult SelectShip()
        {
            IPerson person = new Person();
            string name = StandardMessages.NameReader();
            var apiResult = person.GetAllPersons();
            int page = 1;
            if (apiResult.Result.Any(p => p.Name == name))
            {
                while (true)
                {
                    Console.Clear();
                    Starship APIanswer = GetStarshipsOnePage(page).Result;
                    var shipResult = APIanswer.Results;
                    var nextPage = APIanswer.Next;
                    var previousPage = APIanswer.Previous;

                    var array = ArrayBuilder.ShipArray(shipResult, nextPage, previousPage);
                    var selectedOption = Menu.ShowMenu($"Welcome {name}. What ship will you be parking today?\n", array);
                    
                    if (selectedOption == 0 && previousPage != null)
                    {
                        page--;
                    }
                    else if (selectedOption == array.Length-1 && nextPage != null)
                    {
                        page++;
                    }
                    else
                    {
                        if (previousPage != null) { selectedOption--; } 
                        shipResult[selectedOption].Driver = name;
                        return shipResult[selectedOption];
                    }
                }
            }
            StandardMessages.NotAllowedMessage();
            return null;
        }
    }
}