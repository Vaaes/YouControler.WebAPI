using System.Collections.Generic;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;

namespace YouControler.WebAPI.Services.Interfaces
{
    public interface IDepartamentoRepository
    {
        ValueTask<Departamento> GetDepartamentoById(int id);
        Task AddDepartamento(Departamento entity);
        Task UpdateDepartamento(Departamento entity);
        Task RemoveDepartamento(int id);
        Task<IEnumerable<Departamento>> GetAllDepartamentos();
    }
}
