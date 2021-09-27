using System.Collections.Generic;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;

namespace YouControler.WebAPI.Services.Interfaces
{
    public interface IPerfilRepository
    {
        Task<IEnumerable<Perfil>> GetPerfilAcessoById(int id);
        Task<IEnumerable<Perfil>> GetPerfilAcessoByRole(string Role);
        Task AddPerfilAcesso(Perfil entity);
        Task UpdatePerfilAcesso(Perfil entity);
        Task RemovePerfilAcesso(int id);
        Task<IEnumerable<Perfil>> GetAllPerfilAcesso();
    }
}
