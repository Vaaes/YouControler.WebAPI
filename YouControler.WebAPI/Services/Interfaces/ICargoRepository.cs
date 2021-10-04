using System.Collections.Generic;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;

namespace YouControler.WebAPI.Services.Interfaces
{
    public interface ICargoRepository
    {
        Task<IEnumerable<Cargo>> GetCargoById(int id);
        Task AddCargo(Cargo entity);
        Task<IEnumerable<Cargo>> GetAllCargos();
        Task<IEnumerable<Cargo>> GetCargoName(string Nome);
        Task UpdateCargo(Cargo entity);
        Task RemoveCargo(int id);
    }
}
