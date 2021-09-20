using System.Collections.Generic;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;

namespace YouControler.WebAPI.Services.Interfaces
{
    public interface IFeriasRepository
    {
        ValueTask<Ferias> GetFeriasById(int id);
        Task AddFerias(Ferias entity);
        Task UpdateFerias(Ferias entity);
        Task RemoveFerias(int id);
        Task<IEnumerable<Ferias>> GetAllFerias();
    }
}
