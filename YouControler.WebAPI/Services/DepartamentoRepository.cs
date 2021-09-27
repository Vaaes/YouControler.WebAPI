using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
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
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_INS_DEPARTAMENTO  @NomeDepartamento,@GestorDepartamento,@Andar,@Sala",
                    new
                    {
                        NomeDepartamento = entity.NomeDepartamento,
                        GestorDepartamento = entity.GestorDepartamento,
                        Andar = entity.Andar,
                        Sala = entity.Sala
                    });
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

        public async ValueTask<Departamento> GetDepartamentoById(int id)
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Departamento>("SP_SEL_DEPARTAMENTO_ID @ID", new { Id = id });
                return query;
            });
        }

        public async Task RemoveDepartamento(int id)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_DEL_DEPARTAMENTO @ID", new { Id = id });
            });
        }

        public async Task UpdateDepartamento(Departamento entity)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_UPD_DEPARTAMENTO @NomeDepartamento,@GestorDepartamento,@Andar,@Sala,@ID",
                    new
                    {
                        NomeDepartamento = entity.NomeDepartamento,
                        GestorDepartamento = entity.GestorDepartamento,
                        Andar = entity.Andar,
                        Sala = entity.Sala,
                        ID = entity.Id
                    });
            });
        }
    }
}
