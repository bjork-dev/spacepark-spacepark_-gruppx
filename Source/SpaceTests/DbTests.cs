using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace SpaceTests
{
    public class DbTests : TestDatabase
    {
        [Fact]
        public async Task DatabaseIsAvailableAndCanBeConnectedTo()
        {
            Assert.True(await DbContext.Database.CanConnectAsync());
        }
        [Fact]
        public void TablesShouldGetCreated()
        {
            Assert.True(DbContext.Parkings.Any());
            Assert.True(DbContext.Payments.Any());
        }

        [Fact]
        public void AddedItemShouldGetGeneratedId()
        {
            var newParking = new Parking() { Fee = 100, ShipName = "Test", ParkedBy = "Luke S", MaxLength = 10, Occupied = true };
            DbContext.Parkings.Add(newParking);
            DbContext.SaveChanges();

            Assert.Equal(1, DbContext.Parkings.First().Id);
        }
    }
}
