using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;
using YouControler.WebAPI.Services.Interfaces;

namespace YouControler.WebAPI.Services
{
    public class LogInRepository : BaseRepository, ILogInRepository
    {
        public LogInRepository(IConfiguration configuration) : base(configuration) { }

        public async ValueTask<Usuario> VerificaAcesso(string username, string password)
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Usuario>("SP_GET_USUARIO_VERIFICA_ACESSO @Login, @Senha", new { Login = username, Senha = password });
                return query;
            });
        }
    }
}
