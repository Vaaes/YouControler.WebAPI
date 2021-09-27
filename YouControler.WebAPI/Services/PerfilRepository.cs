using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;
using YouControler.WebAPI.Services.Interfaces;

namespace YouControler.WebAPI.Services
{
    public class PerfilRepository : BaseRepository, IPerfilRepository
    {
        public PerfilRepository(IConfiguration configuration) : base(configuration) { }

        public async Task AddPerfilAcesso(Perfil entity)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Role", value: (object)entity.Role ?? DBNull.Value, dbType: DbType.String);
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_INS_PERFILACESSO @Role", args);
            });
        }

        public async Task<IEnumerable<Perfil>> GetAllPerfilAcesso()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Perfil>("SP_SEL_PERFILACESSO");
                return query;
            });
        }

        public async Task<IEnumerable<Perfil>> GetPerfilAcessoById(int id)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);

            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Perfil>("SP_SEL_PERFILACESSO @Id", args);
                return query;
            });
        }
        public async Task<IEnumerable<Perfil>> GetPerfilAcessoByRole(string Role)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Role", value: (object)Role ?? DBNull.Value, dbType: DbType.Int32);

            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Perfil>("SP_SEL_PERFILACESSO @Role", args);
                return query;
            });
        }


        public async Task RemovePerfilAcesso(int id)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_DEL_PERFILACESSO @Id", args);
            });
        }

        public async Task UpdatePerfilAcesso(Perfil entity)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)entity.Id ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@Role", value: (object)entity.Role ?? DBNull.Value, dbType: DbType.String);
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_UPD_PERFILACESSO @Id, @Role", args);
            });
        }
    }
}
