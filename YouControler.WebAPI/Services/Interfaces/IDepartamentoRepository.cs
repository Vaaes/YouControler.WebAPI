using System.Collections.Generic;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;

namespace YouControler.WebAPI.Services.Interfaces
{
    public interface IDepartamentoRepository
    {
        Task<IEnumerable<Departamento>> GetDepartamentoById(int id);
        Task AddDepartamento(Departamento entity);
        Task UpdateDepartamento(Departamento entity);
        Task RemoveDepartamento(int id);
        Task<IEnumerable<Departamento>> GetAllDepartamentos();
        Task<IEnumerable<Departamento>> GetCargoName(string nome);
    }
}
