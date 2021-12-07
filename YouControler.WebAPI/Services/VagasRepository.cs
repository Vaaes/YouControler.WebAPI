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
    public class VagasRepository : BaseRepository, IVagasRepository
    {
        public VagasRepository(IConfiguration configuration) : base(configuration) { }

        public async Task AddVaga(Vagas entity)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@NomeVaga", value: (object)entity.NomeVaga ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@DataMaxima", value: (object)entity.DataMaxima ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@PerfilVaga", value: (object)entity.PerfilVaga ?? DBNull.Value, dbType: DbType.String);

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_INS_VAGAS @NomeVaga, @DataMaxima, @PerfilVaga", args);
            });
        }

        public async Task<IEnumerable<Vagas>> GetAllVagas()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Vagas>("SP_SEL_VAGAS");
                return query;
            });
        }

        public async Task<IEnumerable<Vagas>> GetVagasById(int id)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);

            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Vagas>("SP_SEL_VAGAS @Id");
                return query;
            });
        }

        public async Task<IEnumerable<Vagas>> GetVagasByParam(int? id = null, string NomeVaga = null, string DataMaxima = null, string PerfilVaga = null)
        {
            try
            {
                var args = new DynamicParameters(new { });
                args.Add(name: "@Id", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);
                args.Add(name: "@NomeVaga", value: (object)NomeVaga ?? DBNull.Value, dbType: DbType.String);
                args.Add(name: "@DataMaxima", value: (object)DataMaxima ?? DBNull.Value, dbType: DbType.String);
                args.Add(name: "@PerfilVaga", value: (object)PerfilVaga ?? DBNull.Value, dbType: DbType.String);

                return await WithConnection(async conn =>
                {
                    var query = await conn.QueryAsync<Vagas>("SP_SEL_VAGAS @Id, @NomeVaga, @DataMaxima, @PerfilVaga", args);
                    return query;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveVaga(int id)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_DEL_VAGAS @Id", args);
            });
        }

        public async Task UpdateVaga(Vagas entity)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)entity.Id ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@NomeVaga", value: (object)entity.NomeVaga ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@DataMaxima", value: (object)entity.DataMaxima ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@PerfilVaga", value: (object)entity.PerfilVaga ?? DBNull.Value, dbType: DbType.String);

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_UPD_VAGAS @Id, @NomeVaga, @DataMaxima, @PerfilVaga", args);
            });
        }
    }
}
