using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;

namespace YouControler.WebAPI.Services.Interfaces
{
    public interface IVagasRepository
    {
        Task<IEnumerable<Vagas>> GetVagasById(int id);
        Task<IEnumerable<Vagas>> GetVagasByParam(int? id = null, string NomeVaga = null, string DataMaxima = null, string PerfilVaga = null);
        Task AddVaga(Vagas entity);
        Task<IEnumerable<Vagas>> GetAllVagas();
        Task UpdateVaga(Vagas entity);
        Task RemoveVaga(int id);
    }
}
