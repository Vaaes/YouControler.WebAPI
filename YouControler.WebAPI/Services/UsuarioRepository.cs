using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;
using YouControler.WebAPI.Services.Interfaces;

namespace YouControler.WebAPI.Services
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        public UsuarioRepository(IConfiguration configuration) : base(configuration) { }

        public async Task AddUsuario(Usuario entity)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_INS_USUARIO",
                    new
                    {
                        Nome = entity.Nome,
                        CPF = entity.CPF,
                        Nascimento = entity.Nascimento,
                        Telefone_Celular = entity.Telefone_Celular,
                        Telefone_Residencial = entity.Telefone_Residencial,
                        Email = entity.Email,
                        CEP = entity.CEP,
                        Login = entity.Login,
                        Senha = entity.Senha
                    });
            });
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuario()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Usuario>("SP_SEL_USUARIO");
                return query;
            });
        }

        public async ValueTask<Usuario> GetUsuarioById(int id)
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Usuario>("", new { Id = id });
                return query;
            });
        }

        public async Task RemoveUsuario(int id)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_DEL_USUARIO", new { Id = id });
            });
        }

        public async Task UpdateUsuario(Usuario entity)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_UPD_USUARIO",
                    new
                    {
                        Id = entity.Id,
                        Nome = entity.Nome,
                        CPF = entity.CPF,
                        Nascimento = entity.Nascimento,
                        Telefone_Celular = entity.Telefone_Celular,
                        Telefone_Residencial = entity.Telefone_Residencial,
                        Email = entity.Email,
                        CEP = entity.CEP,
                        Login = entity.Login,
                        Senha = entity.Senha
                    });
            });
        }
    }
}
