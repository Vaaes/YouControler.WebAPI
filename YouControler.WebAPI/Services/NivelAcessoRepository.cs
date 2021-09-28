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
    public class NivelAcessoRepository : BaseRepository, INivelAcessoRepository
    {
        public NivelAcessoRepository(IConfiguration configuration) : base(configuration) { }

        public async Task AddNivelAcesso(NivelAcesso entity)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@IdMenus", value: (object)entity.IdMenus ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@IdNivelAcesso", value: (object)entity.IdNivelAcesso ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@Acesso", value: (object)entity.Acesso ?? DBNull.Value, dbType: DbType.Int32);

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_INS_NIVELACESSO @IdMenus, @IdNivelAcesso, @Acesso", args);
            });
        }

        public async Task<IEnumerable<NivelAcesso>> GetAllNivelAcesso()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<NivelAcesso>("SP_SEL_NIVELACESSO");
                return query;
            });
        }

        public async Task<IEnumerable<NivelAcesso>> GetNivelAcessoById(int id)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<NivelAcesso>("SP_SEL_NIVELACESSO @Id", args);
                return query;
            });
        }

        public async Task<IEnumerable<NivelAcesso>> GetNivelAcessoByRole(string IdNivelAcesso)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@IdNivelAcesso", value: (object)IdNivelAcesso ?? DBNull.Value, dbType: DbType.Int32);

            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<NivelAcesso>("SP_SEL_NIVELACESSO @IdNivelAcesso", args);
                return query;
            });
        }

        public async Task RemoveNivelAcesso(int id)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_DEL_NIVELACESSO @Id", args);
            });
        }

        public async Task UpdateNivelAcesso(NivelAcesso entity)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)entity.Id ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@IdMenus", value: (object)entity.IdMenus ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@IdNivelAcesso", value: (object)entity.IdNivelAcesso ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@Acesso", value: (object)entity.Acesso ?? DBNull.Value, dbType: DbType.Int32);

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_UPD_NIVELACESSO @Id, @IdMenus, @IdNivelAcesso, @Acesso", args);
            });
        }
    }
}
