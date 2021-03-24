using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IPerson
    {
        Task<List<Results>> GetAllPersons();
    }
}