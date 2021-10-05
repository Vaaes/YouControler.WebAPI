using System.Collections.Generic;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;

namespace YouControler.WebAPI.Services.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetUsuarioById(int? id = null, string nome = null, int? IdNivelAcesso = null, string cpf = null, string email = null, string usuario = null);
        Task<IEnumerable<Usuario>> GetVerificaPerfil(int id);
        Task AddUsuario(Usuario entity);
        Task UpdateUsuario(Usuario entity);
        Task RemoveUsuario(int id);
        Task<IEnumerable<Usuario>> GetAllUsuario();
    }
}
