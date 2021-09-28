using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
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
            var args = new DynamicParameters(new { });
            args.Add(name: "@Login", value: (object)username ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Senha", value: (object)password ?? DBNull.Value, dbType: DbType.Int32);
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Usuario>("SP_SEL_USUARIO_VERIFICA_ACESSO @Login, @Senha", args);
                return query;
            });
        }
        public async Task<IEnumerable<ControleAcesso>> GetAllControleAcesso(int IdNivelAcesso)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)IdNivelAcesso ?? DBNull.Value, dbType: DbType.Int32);
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<ControleAcesso>("SP_SEL_CONTROLE_ACESSO_MENU @Id", args);
                return query;
            });
        }

    }
}
