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
            var args = new DynamicParameters(new { });
            args.Add(name: "@IdMenu", value: (object)entity.IdMenu ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@IdPerfilAcesso", value: (object)entity.IdPerfilAcesso ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@CRIAR", value: (object)entity.CRIAR ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@LER", value: (object)entity.LER ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@ALTERAR", value: (object)entity.ALTERAR ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@DELETAR", value: (object)entity.DELETAR ?? DBNull.Value, dbType: DbType.Int32);

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_INS_PERMISSOES @IdMenu, @IdPerfilAcesso, @CRIAR, @LER, @ALTERAR, @DELETAR", args);
            });
        }

        public async Task<IEnumerable<Permissoes>> GetPermissionByProfile(int IdPerfilAcesso)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@IdPerfilAcesso", value: (object)IdPerfilAcesso ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@IdMenu", value: DBNull.Value, dbType: DbType.Int32);
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Permissoes>("SP_SEL_VERIFICA_PERMISSOES @IdPerfilAcesso, @IdMenu", args);
                return query;
            });
        }

        public async Task<IEnumerable<Permissoes>> HasPermission(int IdPerfilAcesso, int IdMenu)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@IdPerfilAcesso", value: (object)IdPerfilAcesso ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@IdMenu", value: (object)IdMenu ?? DBNull.Value, dbType: DbType.Int32);
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Permissoes>("SP_SEL_VERIFICA_PERMISSOES @IdPerfilAcesso, @IdMenu", args);
                return query;
            });
        }

        public async Task RemovePermissoes(int id)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_DEL_PERMISSOES @Id", args);
            });
        }

        public async Task UpdatePermissoes(Permissoes entity)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)entity.Id ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@IdMenu", value: (object)entity.IdMenu ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@IdPerfilAcesso", value: (object)entity.IdPerfilAcesso ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@CRIAR", value: (object)entity.CRIAR ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@LER", value: (object)entity.LER ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@ALTERAR", value: (object)entity.ALTERAR ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@DELETAR", value: (object)entity.DELETAR ?? DBNull.Value, dbType: DbType.Int32);

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_UPD_PERMISSOES @Id, @IdMenu, @IdPerfilAcesso, @CRIAR, @LER, @ALTERAR, @DELETAR", args);
            });
        }
    }
}
