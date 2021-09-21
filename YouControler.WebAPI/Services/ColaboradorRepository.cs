using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;
using YouControler.WebAPI.Services.Interfaces;

namespace YouControler.WebAPI.Services
{
    public class ColaboradorRepository : BaseRepository, IColaboradorRepository
    {
        public ColaboradorRepository(IConfiguration configuration) : base(configuration) { }

        public async Task AddColaborador(Colaborador entity)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_INS_COLABORADOR",
                    new
                    {
                        Name = entity.Nome,
                        Cost = entity.Nascimento
                    });
            });
        }

        public async Task<IEnumerable<Colaborador>> GetAllColaboradores()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Colaborador>("");
                return query;
            });
        }

        public async ValueTask<Colaborador> GetColaboradorById(string CPF)
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Colaborador>("SP_SEL_COLABORADOR_CPF", new { CPF = CPF });
                return query;
            });
        }

        public async Task RemoveColaborador(string CPF)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_DEL_COLABORADOR_CPF", new { CPF = CPF });
            });
        }

        public async Task UpdateColaborador(Colaborador entity)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_UPD_COLABORADOR",
                    new
                    {
                        Name = entity.Nome,
                        Cost = entity.Nascimento,
                        entity.Id
                    });
            });
        }
    }
}
