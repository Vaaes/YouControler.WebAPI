using System.Collections.Generic;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;

namespace YouControler.WebAPI.Services.Interfaces
{
    public interface INivelAcessoRepository
    {
        ValueTask<NivelAcesso> GetNivelAcessoById(int id);
        Task AddNivelAcesso(NivelAcesso entity);
        Task UpdateNivelAcesso(NivelAcesso entity);
        Task RemoveNivelAcesso(int id);
        Task<IEnumerable<NivelAcesso>> GetAllNivelAcesso();
    }
}
