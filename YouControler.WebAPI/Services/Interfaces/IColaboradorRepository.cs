using System.Collections.Generic;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;

namespace YouControler.WebAPI.Services.Interfaces
{
    public interface IColaboradorRepository
    {
        ValueTask<Colaborador> GetColaboradorById(string CPF);
        Task AddColaborador(Colaborador entity);
        Task UpdateColaborador(Colaborador entity);
        Task RemoveColaborador(string CPF);
        Task<IEnumerable<Colaborador>> GetAllColaboradores();
    }
}
