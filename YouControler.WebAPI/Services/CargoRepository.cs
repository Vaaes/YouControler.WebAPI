using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
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
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("",
                    new { Name = entity.Nome_Cargo, Cost = entity.Nome_Cargo });
            });
        }

        public async Task<IEnumerable<Cargo>> GetAllCargos()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Cargo>("GET_CARGO");
                return query;
            });
        }

        public async ValueTask<Cargo> GetCargoById(int id)
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Cargo>("", new { Id = id });
                return query;
            });
        }

        public async Task RemoveCargo(int id)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("", new { Id = id });
            });
        }

        public async Task UpdateCargo(Cargo entity)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("",
                    new { Name = entity.Nome_Cargo, Cost = entity.Descricao_Cargo, entity.Id });
            });
        }
    }
}
