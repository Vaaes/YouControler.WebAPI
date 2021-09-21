using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
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
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_INS_FERIAS",
                    new
                    {
                        Nome = entity.Data_Inicio,
                        CPF = entity.Data_Final,
                        Nascimento = entity.IdUsuario,
                        Telefone_Celular = entity.Aprovado
                    });
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

        public async ValueTask<Ferias> GetFeriasById(int id)
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Ferias>("", new { Id = id });
                return query;
            });
        }

        public async Task RemoveFerias(int id)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_DEL_FERIAS", new { Id = id });
            });
        }

        public async Task UpdateFerias(Ferias entity)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_UPD_FERIAS",
                    new
                    {
                        Id = entity.Id,
                        Nome = entity.Data_Inicio,
                        CPF = entity.Data_Final,
                        Nascimento = entity.IdUsuario,
                        Telefone_Celular = entity.Aprovado
                    });
            });
        }
    }
}
