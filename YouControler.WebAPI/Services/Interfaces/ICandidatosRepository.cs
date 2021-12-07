using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;

namespace YouControler.WebAPI.Services.Interfaces
{
    public interface ICandidatosRepository
    {
        Task<IEnumerable<Candidatos>> GetCandidatosById(int id);
        Task<IEnumerable<Candidatos>> GetCandidatosByParam(int? id = null, string NomeCandidato = null, int? IdadeCandidato = null, string EmailCandidato = null, string TelefoneCandidato = null, int? IdVaga = null);
        Task AddCandidato(Candidatos entity);
        Task<IEnumerable<Candidatos>> GetAllCandidatos();
        Task UpdateCandidato(Candidatos entity);
        Task RemoveCandidato(int id);
    }
}
