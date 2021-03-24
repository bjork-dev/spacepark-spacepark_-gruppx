using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;

namespace ClassLibrary
{
    public class Person : IPerson
    {
        public int Id { get; set; }
        public string Count { get; set; }
        public List<Results> Results { get; set; }
        private async Task<List<Results>> GetPersonsOnePage(int page)
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest($"people/?page={page}", DataFormat.Json);
            var response = await client.GetAsync<Person>(request);
            return response.Results;
        }
        private static async Task<Person> GetInfo()
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest($"people/", DataFormat.Json);
            var response = await client.GetAsync<Person>(request);
            return response;
        }
        private Task<List<Results>> CreateTask(int i)
        {
            return Task.Run(() => GetPersonsOnePage(i).Result);
        }
        public async Task<List<Results>> GetAllPersons()
        {
            Person p = await GetInfo();  
            int numberOfPersons = int.Parse(p.Count);
            int personsPerOnePage = p.Results.Count;
            int numberOfPages = (int)Math.Ceiling(1.0 * numberOfPersons / personsPerOnePage);

            var tasks = new List<Task<List<Results>>>();
            for (int i = 1; i < numberOfPages + 1; i++)
            {
                tasks.Add(CreateTask(i));
            }

            List<Results> temp = new List<Results>();

            for (int i = 0; i < numberOfPages; i++)
            {
                temp.AddRange(tasks[i].Result);
            }
            return temp;
        }
    }

    public class Results
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Height { get; set; }
    }
}
