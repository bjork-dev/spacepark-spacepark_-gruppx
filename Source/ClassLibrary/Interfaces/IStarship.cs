using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IStarship
    {
       public Task<Starship> GetStarshipsOnePage(int page);
       public IShipResult SelectShip();
    }
}