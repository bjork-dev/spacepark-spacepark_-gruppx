using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IStarship
    {
        public Task<ShipResult> GetStarships(string address);
        public IShipResult SelectShip();
    }
}