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
    public class CandidatosRepository : BaseRepository, ICandidatosRepository
    {
        public CandidatosRepository(IConfiguration configuration) : base(configuration) { }

        public async Task AddCandidato(Candidatos entity)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@NomeCandidato", value: (object)entity.NomeCandidato ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@IdadeCandidato", value: (object)entity.IdadeCandidato ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@EmailCandidato", value: (object)entity.EmailCandidato ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@TelefoneCandidato", value: (object)entity.TelefoneCandidato ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@IdVaga", value: (object)entity.IdVaga ?? DBNull.Value, dbType: DbType.Int32);

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_INS_CANDIDADATOS @NomeCandidato, @IdadeCandidato, @EmailCandidato, @TelefoneCandidato, @IdVaga", args);
            });
        }

        public async Task<IEnumerable<Candidatos>> GetAllCandidatos()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Candidatos>("SP_SEL_CANDIDADATOS");
                return query;
            });
        }

        public async Task<IEnumerable<Candidatos>> GetCandidatosById(int id)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);

            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Candidatos>("SP_SEL_CANDIDADATOS @ID");
                return query;
            });
        }

        public async Task<IEnumerable<Candidatos>> GetCandidatosByParam(int? id = null, string NomeCandidato = null, int? IdadeCandidato = null, string EmailCandidato = null, string TelefoneCandidato = null, int? IdVaga = null)
        {
            try
            {
                var args = new DynamicParameters(new { });
                args.Add(name: "@Id", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);
                args.Add(name: "@NomeCandidato", value: (object)NomeCandidato ?? DBNull.Value, dbType: DbType.String);
                args.Add(name: "@IdadeCandidato", value: (object)IdadeCandidato ?? DBNull.Value, dbType: DbType.Int32);
                args.Add(name: "@EmailCandidato", value: (object)EmailCandidato ?? DBNull.Value, dbType: DbType.String);
                args.Add(name: "@TelefoneCandidato", value: (object)TelefoneCandidato ?? DBNull.Value, dbType: DbType.String);
                args.Add(name: "@IdVaga", value: (object)IdVaga ?? DBNull.Value, dbType: DbType.Int32);

                return await WithConnection(async conn =>
                {
                    var query = await conn.QueryAsync<Candidatos>("SP_SEL_CANDIDADATOS @Id, @NomeCandidato, @IdadeCandidato, @EmailCandidato, @TelefoneCandidato, @IdVaga", args);
                    return query;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveCandidato(int id)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_DEL_CANDIDADATOS @Id", args);
            });
        }

        public async Task UpdateCandidato(Candidatos entity)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)entity.Id ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@NomeCandidato", value: (object)entity.NomeCandidato ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@IdadeCandidato", value: (object)entity.IdadeCandidato ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@EmailCandidato", value: (object)entity.EmailCandidato ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@TelefoneCandidato", value: (object)entity.TelefoneCandidato ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@IdVaga", value: (object)entity.IdVaga ?? DBNull.Value, dbType: DbType.Int32);

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_UPD_CANDIDADATOS @Id, @NomeCandidato, @IdadeCandidato, @EmailCandidato, @TelefoneCandidato, @IdVaga", args);
            });
        }
    }
}
