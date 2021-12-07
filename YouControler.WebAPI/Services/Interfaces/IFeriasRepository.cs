using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;

namespace YouControler.WebAPI.Services.Interfaces
{
    public interface IFeriasRepository
    {
        Task<IEnumerable<Ferias>> GetFeriasByParam(string Data_Inicio = null, string Data_Final = null, int? Id = null, int? IdUsuario = null, bool? Aprovado = null);
        Task<IEnumerable<Ferias>> GetAprovacao(int Aprovado);
        Task AddFerias(Ferias entity); 
         Task UpdateFerias(Ferias entity);
        Task UpdateAprovaFerias(int id, int Aprovado);
        Task RemoveFerias(int id);
        Task<IEnumerable<Ferias>> GetAllFerias();
    }
}
