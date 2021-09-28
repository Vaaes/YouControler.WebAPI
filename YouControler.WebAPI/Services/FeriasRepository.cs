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
    public class FeriasRepository : BaseRepository, IFeriasRepository
    {
        public FeriasRepository(IConfiguration configuration) : base(configuration) { }

        public async Task AddFerias(Ferias entity)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Data_Inicio", value: (object)entity.Data_Inicio ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Data_Final", value: (object)entity.Data_Final ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@IdUsuario", value: (object)entity.IdUsuario ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Aprovado", value: (object)entity.Aprovado ?? DBNull.Value, dbType: DbType.String);

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_INS_FERIAS @Data_Inicio, @Data_Final, @IdUsuario, @Aprovado", args);
            });
        }

        public async Task<IEnumerable<Ferias>> GetAllFerias()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Ferias>("SP_GET_FERIAS");
                return query;
            });
        }

        public async ValueTask<Ferias> GetFeriasById(int id)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Ferias>("SP_SEL_FERIAS_ID @ID", args);
                return query;
            });
        }

        public async Task RemoveFerias(int id)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_DEL_FERIAS", args);
            });
        }

        public async Task UpdateFerias(Ferias entity)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)entity.Id ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Data_Inicio", value: (object)entity.Data_Inicio ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Data_Final", value: (object)entity.Data_Final ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@IdUsuario", value: (object)entity.IdUsuario ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Aprovado", value: (object)entity.Aprovado ?? DBNull.Value, dbType: DbType.String);

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_UPD_NIVELACESSO @Id, @Data_Inicio, @Data_Final, @IdUsuario, @Aprovado", args);
            });
        }
    }
}
