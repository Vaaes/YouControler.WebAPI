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
    public class CargoRepository : BaseRepository, ICargoRepository
    {
        public CargoRepository(IConfiguration configuration) : base(configuration) { }

        public async Task AddCargo(Cargo entity)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Nome", value: (object)entity.Nome_Cargo ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Descricao", value: (object)entity.Descricao_Cargo ?? DBNull.Value, dbType: DbType.String);

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_INS_CARGO @Nome, @Descricao", args);
            });
        }

        public async Task<IEnumerable<Cargo>> GetAllCargos()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Cargo>("SP_SEL_CARGO");
                return query;
            });
        }

        public async ValueTask<Cargo> GetCargoById(int id)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@ID", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Cargo>("SP_SEL_CARGO_ID @ID", args);
                return query;
            });
        }

        public async Task RemoveCargo(int id)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@ID", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_DEL_CARGO @ID", args);
            });
        }

        public async Task UpdateCargo(Cargo entity)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@ID", value: (object)entity.Id ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@Nome", value: (object)entity.Nome_Cargo ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Descricao", value: (object)entity.Descricao_Cargo ?? DBNull.Value, dbType: DbType.String);
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_UPD_CARGO @ID, @Nome, @Descricao", args);
            });
        }
    }
}
