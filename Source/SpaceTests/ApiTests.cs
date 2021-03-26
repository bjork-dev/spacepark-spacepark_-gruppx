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
        public static void When_Calling_People_Except_List_OfType_Person_Results()
        {
            // Arrange
            IPersonApi person = new PersonApi();
            // Act
            var list = person.GetAllPersons();
            // Assert
            Assert.IsType<List<Results>>(list.Result);
        }
        //[Fact]
        //public static void When_Calling_Starships_Except_List_OfType_Starship_ShipResult()
        //{
        //    // Arrange
        //    IStarship person = new Starship();
        //    // Act
        //    var list = person.GetStarships();
        //    // Assert
        //    Assert.IsType<List<ShipResult>>(list.Result);
        //}
        [Fact]
        public static void When_Calling_People_Except_82_Objects_OfType_Result()
        {
            // Arrange
            IPersonApi person = new PersonApi();
            // Act
            var list = person.GetAllPersons();
            // Assert
            Assert.Equal(82, list.Result.Count);
        }
        //[Fact]
        //public static void When_Calling_Starships_And_NoShips_AreParked_Except_10_Objects_OfType_ShipResult()
        //{
        //    // Arrange
        //    IStarship starship = new Starship();
        //    // Act
        //    var list = starship.GetStarships();
        //    // Assert
        //    Assert.Equal(10, list.Result.Count);
        //}
    }
}
