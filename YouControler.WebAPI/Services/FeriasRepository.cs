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
            args.Add(name: "@IdUsuario", value: (object)entity.IdUsuario ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@Aprovado", value: (object)entity.Aprovado ?? DBNull.Value, dbType: DbType.Int32);

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_INS_FERIAS @Data_Inicio, @Data_Final, @IdUsuario, @Aprovado", args);
            });
        }

        public async Task<IEnumerable<Ferias>> GetAllFerias()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Ferias>("SP_SEL_FERIAS");
                return query;
            });
        }

        public async Task<IEnumerable<Ferias>> GetFeriasByParam(string Data_Inicio = null, string Data_Final = null, int? Id = null, int? IdUsuario = null, bool? Aprovado = null)
        {
            try
            {
                var args = new DynamicParameters(new { });
                args.Add(name: "@Id", value: (object)Id ?? DBNull.Value, dbType: DbType.Int32);
                args.Add(name: "@Data_Inicio", value: (object)Data_Inicio ?? DBNull.Value, dbType: DbType.String);
                args.Add(name: "@Data_Final", value: (object)Data_Final ?? DBNull.Value, dbType: DbType.String);
                args.Add(name: "@IdUsuario", value: (object)IdUsuario ?? DBNull.Value, dbType: DbType.Int32);
                args.Add(name: "@Aprovado", value: (object)Aprovado ?? DBNull.Value, dbType: DbType.Int32);

                return await WithConnection(async conn =>
                { 
                    var query = await conn.QueryAsync<Ferias>("SP_SEL_FERIAS @Id, @Data_Inicio, @Data_Final, @IdUsuario, @Aprovado", args);
                    return query;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public async Task RemoveFerias(int id)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_DEL_FERIAS @Id", args);
            });
        }

        public async Task UpdateFerias(Ferias entity)
        {
            try
            {
                var args = new DynamicParameters(new { });
                args.Add(name: "@Id", value: (object)entity.Id ?? DBNull.Value, dbType: DbType.Int32);
                args.Add(name: "@Data_Inicio", value: (object)entity.Data_Inicio ?? DBNull.Value, dbType: DbType.String);
                args.Add(name: "@Data_Final", value: (object)entity.Data_Final ?? DBNull.Value, dbType: DbType.String);
                args.Add(name: "@IdUsuario", value: (object)entity.IdUsuario ?? DBNull.Value, dbType: DbType.Int32);
                args.Add(name: "@Aprovado", value: (object)0 ?? DBNull.Value, dbType: DbType.Int32);

                await WithConnection(async conn =>
                {
                    await conn.ExecuteAsync("SP_UPD_FERIAS @Id, @Data_Inicio, @Data_Final, @IdUsuario, @Aprovado", args);
                });
            }
            catch (Exception ex){
                throw ex;
            }
        }
    }
}
