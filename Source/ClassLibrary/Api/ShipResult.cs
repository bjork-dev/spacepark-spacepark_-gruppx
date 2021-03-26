using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ShipResult : IShipResult
    {
        public string Name { get; set; }
        public decimal Length { get; set; }
        public string Driver { get; set; }

        public async Task<ShipResult> GetStarships(string address)
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("starships/" + address, DataFormat.Json);
            var response = await client.GetAsync<ShipResult>(request);

            return response;
        }
        private async Task<ShipResult> CreateTask(string address)
        {
            return await Task.Run(() => GetStarships(address));
        }
        private static List<ShipResult> RemoveParkedShips(List<ShipResult> ownShips)
        {
            using var context = new SpaceContext();
            var parkedShips = context.Parkings.Where(p => p.Occupied).ToList();
            for (int i = 0; i < parkedShips.Count; i++)
            {
                var name = parkedShips[i].User;
                if (ownShips.Any(n => n.Name == name))
                {
                    var index = ownShips.First(s => s.Name == name);
                    ownShips.Remove(index);
                }
            }
            return ownShips;
        }
        private static List<string> FindAddressNumber(List<string> shipsAddresses)
        {
            List<string> addressNumber = new();
            foreach (string s in shipsAddresses)
            {
                int index = s.TrimEnd('/').LastIndexOf('/');
                string address = s.Substring(index + 1);
                addressNumber.Add(address);
            }
            return addressNumber;
        }
        public IShipResult SelectShip()
        {
            IPerson person = new Person();
            string name = StandardMessages.NameReader();
            var apiResult = person.GetAllPersons();
            Results user = apiResult.Result.FirstOrDefault(p => p.Name == name);

            if (user != null)
            {
                Console.Clear();

                List<string> shipsAddresses = user.Starships;
                if (shipsAddresses.Count != 0)
                {
                    List<string> addressNumber = FindAddressNumber(shipsAddresses);
                    List<ShipResult> ownShips = new();
                    foreach (string s in addressNumber)
                    {
                        ownShips.Add(CreateTask(s).Result);
                    }
                    ownShips = RemoveParkedShips(ownShips);

                    if (ownShips.Count != 0)
                    {
                        var array = ArrayBuilder.ShipArray(ownShips);
                        var selectedOption = Menu.ShowMenu($"Welcome {name}. What ship will you be parking today?\n", array);

                        ownShips[selectedOption].Driver = name;
                        return ownShips[selectedOption];
                    }
                    Console.WriteLine("Sorry, all your ships are already parked.");
                    Console.ReadKey();
                    return null;
                }
                Console.WriteLine("Sorry, you don't have any ships.");
                Console.ReadKey();
                return null;
            }
            StandardMessages.NotAllowedMessage();
            return null;
        }
    }
}