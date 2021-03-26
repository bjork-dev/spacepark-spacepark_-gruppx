using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Api;

namespace ClassLibrary
{
    public class Starship : IStarship
    {
        public string Name { get; set; }
        public decimal Length { get; set; }
        public string Driver { get; set; }

    }
}