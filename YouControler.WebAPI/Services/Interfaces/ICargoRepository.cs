using System.Collections.Generic;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;

namespace YouControler.WebAPI.Services.Interfaces
{
    public interface ICargoRepository
    {
        ValueTask<Cargo> GetCargoById(int id);
        Task AddCargo(Cargo entity);
        Task UpdateCargo(Cargo entity);
        Task RemoveCargo(int id);
        Task<IEnumerable<Cargo>> GetAllCargos();
    }
}
