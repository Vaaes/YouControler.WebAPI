using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;
using YouControler.WebAPI.Services.Interfaces;

namespace YouControler.WebAPI.Services
{
    public class PermissoesRepository : BaseRepository, IPermissoesRepository
    {
        public PermissoesRepository(IConfiguration configuration) : base(configuration) { }

        public async Task AddPermissoes(Permissoes entity)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_INS_PERMISSOES @IdMenu, @IdPerfilAcesso, @CRIAR, @LER, @ALTERAR, @DELETAR",
                    new
                    {
                        IdMenu = entity.IdMenu,
                        IdPerfilAcesso = entity.IdPerfilAcesso,
                        CRIAR = entity.CRIAR,
                        LER = entity.LER,
                        ALTERAR = entity.ALTERAR,
                        DELETAR = entity.DELETAR
                    });
            });
        }

        public async Task<IEnumerable<Permissoes>> HasPermission(int IdPerfilAcesso, int IdMenu)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@IdPerfilAcesso", value: (object)IdPerfilAcesso ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@IdMenu", value: (object)IdMenu ?? DBNull.Value, dbType: DbType.String);
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Permissoes>("SP_SEL_VERIFICA_PERMISSOES @IdPerfilAcesso, @IdMenu", args);
                return query;
            });
        }

        public async Task RemovePermissoes(int id)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_DEL_PERMISSOES", new { Id = id });
            });
        }

        public async Task UpdatePermissoes(Permissoes entity)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_UPD_PERMISSOES @Id, @IdMenu, @IdPerfilAcesso, @CRIAR, @LER, @ALTERAR, @DELETAR",
                    new
                    {
                        Id = entity.Id,
                        IdMenu = entity.IdMenu,
                        IdPerfilAcesso = entity.IdPerfilAcesso,
                        CRIAR = entity.CRIAR,
                        LER = entity.LER,
                        ALTERAR = entity.ALTERAR,
                        DELETAR = entity.DELETAR
                    });
            });
        }
    }
}
