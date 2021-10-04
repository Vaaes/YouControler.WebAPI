using System.Collections.Generic;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;

namespace YouControler.WebAPI.Services.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task<IEnumerable<Funcionario>> GetFuncionariooByParam(int? id = null, string nome = null, string CPF = null, string Tipo = null, string email = null, string Salario = null, int? IdCargo = null);
        Task AddUFuncionario(Funcionario entity);
        Task UpdateFuncionario(Funcionario entity);
        Task RemoveFuncionario(int id);
        Task<IEnumerable<Funcionario>> GetAllFuncionario();

    }
}
