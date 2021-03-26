using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary.Api
{
    public interface IPersonApi
    {
        Task<List<Results>> GetAllPersons();
    }
}