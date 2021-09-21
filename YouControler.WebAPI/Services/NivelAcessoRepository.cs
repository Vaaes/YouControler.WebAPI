using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
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
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_INS_NIVELACESSO",
                    new
                    {
                        Role = entity.Role,
                    });
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

        public async ValueTask<NivelAcesso> GetNivelAcessoById(int id)
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<NivelAcesso>("", new { Id = id });
                return query;
            });
        }

        public async Task RemoveNivelAcesso(int id)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_DEL_NIVELACESSO", new { Id = id });
            });
        }

        public async Task UpdateNivelAcesso(NivelAcesso entity)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_UPD_NIVELACESSO",
                    new
                    {
                        Id = entity.Id,
                        Role = entity.Role,
                    });
            });
        }
    }
}
