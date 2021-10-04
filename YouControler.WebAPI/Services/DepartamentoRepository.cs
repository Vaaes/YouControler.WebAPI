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
    public class DepartamentoRepository : BaseRepository, IDepartamentoRepository
    {
        public DepartamentoRepository(IConfiguration configuration) : base(configuration) { }

        public async Task AddDepartamento(Departamento entity)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@NomeDepartamento", value: (object)entity.NomeDepartamento ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@GestorDepartamento", value: (object)entity.GestorDepartamento ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Andar", value: (object)entity.Andar ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Sala", value: (object)entity.Sala ?? DBNull.Value, dbType: DbType.String);
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_INS_DEPARTAMENTO @NomeDepartamento, @GestorDepartamento, @Andar, @Sala", args);
            });
        }

        public async Task<IEnumerable<Departamento>> GetAllDepartamentos()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Departamento>("SP_SEL_DEPARTAMENTO");
                return query;
            });
        }

        public async Task<IEnumerable<Departamento>> GetCargoName(string nome)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Nome", value: (object)nome ?? DBNull.Value, dbType: DbType.String);
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Departamento>("SP_SEL_DEPARTAMENTO_NOME @Nome", args);
                return query;
            });
        }

        public async Task<IEnumerable<Departamento>> GetDepartamentoById(int id)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@ID", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);

            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Departamento>("SP_SEL_DEPARTAMENTO_ID @ID", args);
                return query;
            });
        }

        public async Task RemoveDepartamento(int id)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@ID", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_DEL_DEPARTAMENTO @ID", args);
            });
        }

        public async Task UpdateDepartamento(Departamento entity)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@NomeDepartamento", value: (object)entity.NomeDepartamento ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@GestorDepartamento", value: (object)entity.GestorDepartamento ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Andar", value: (object)entity.Andar ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Sala", value: (object)entity.Sala ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@ID", value: (object)entity.Id ?? DBNull.Value, dbType: DbType.Int32);

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_UPD_DEPARTAMENTO @NomeDepartamento, @GestorDepartamento, @Andar, @Sala, @ID", args);
            });
        }
    }
}
