using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using ClassLibrary.Api;
using Xunit;

namespace SpaceTests
{
    public class ApiTests
    {
        [Fact]
        public static void When_Calling_People_Expect_List_OfType_Person_Results()
        {
            // Arrange
            IPersonApi person = new PersonApi();
            // Act
            var list = person.GetAllPersons();
            // Assert
            Assert.IsType<List<Results>>(list.Result);
        }
        [Fact]
        public static void When_Calling_People_Expect_82_Objects_OfType_Result()
        {
            // Arrange
            IPersonApi person = new PersonApi();
            // Act
            var list = person.GetAllPersons();
            // Assert
            Assert.Equal(82, list.Result.Count);
        }
        [Fact]
        public static void When_Calling_GetStarships_Twelve_Expect_xWing()
        {
            Task<Starship> xWing = ShipApi.GetStarships("12/");
            Assert.Equal("X-wing", xWing.Result.Name);
        }
        [Fact]
        public static void When_Calling_GetShipNumber_Expect_KeyList()
        {
            IEnumerable<string> inputList = new List<string>
            {
                "http://swapi.dev/api/starships/12/",
                "http://swapi.dev/api/starships/22/"
            };
            IEnumerable<string> outputList = ShipApi.GetShipNumber(inputList);
            IEnumerable<string> keyList = new List<string> { "12/", "22/" };
            Assert.Equal(keyList, outputList);
        }

    }
}
