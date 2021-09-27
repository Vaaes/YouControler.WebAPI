using System.Collections.Generic;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;

namespace YouControler.WebAPI.Services.Interfaces
{
    public interface INivelAcessoRepository
    {
        Task<IEnumerable<NivelAcesso>> GetNivelAcessoById(int id);
        Task<IEnumerable<NivelAcesso>> GetNivelAcessoByRole(string Role);
        Task AddNivelAcesso(NivelAcesso entity);
        Task UpdateNivelAcesso(NivelAcesso entity);
        Task RemoveNivelAcesso(int id);
        Task<IEnumerable<NivelAcesso>> GetAllNivelAcesso();
    }
}
