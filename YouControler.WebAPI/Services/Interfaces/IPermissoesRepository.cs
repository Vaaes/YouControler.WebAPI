using System.Collections.Generic;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;

namespace YouControler.WebAPI.Services.Interfaces
{
    public interface IPermissoesRepository
    {
        Task<IEnumerable<Permissoes>> HasPermission(int IdPerfilAcesso, int Menu);
        Task<IEnumerable<Permissoes>> GetPermissionByProfile(int IdPerfilAcesso);
        Task AddPermissoes(Permissoes entity);
        Task UpdatePermissoes(Permissoes entity);
        Task RemovePermissoes(int id);
    }
}
