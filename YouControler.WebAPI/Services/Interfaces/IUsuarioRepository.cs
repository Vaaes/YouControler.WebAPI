using System.Collections.Generic;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;

namespace YouControler.WebAPI.Services.Interfaces
{
    public interface IUsuarioRepository
    {
        ValueTask<Usuario> GetUsuarioById(int id);
        Task AddUsuario(Usuario entity);
        Task UpdateUsuario(Usuario entity);
        Task RemoveUsuario(int id);
        Task<IEnumerable<Usuario>> GetAllUsuario();
    }
}
