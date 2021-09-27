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
                await conn.ExecuteAsync("SP_INS_COLABORADOR @Nome,@CPF,@Dt_Nascimento,@Telefone_Celular, @Telefone_Residencial,@Email, @CEP, @Endereco_Rua, @Endereco_Numero,@Endereco_Bairro," +
                    " @Endereco_Cidade,@Endereco_Estado,@Estado_Civil,@Filhos,@Qnt_Filhos,@Escolaridade,@Departamento,@Ativo,@Salario",
                    new
                    {
                        entity.Nome,
                        entity.CPF,
                        entity.Dt_Nascimento,
                        entity.Telefone_Celular,
                        entity.Telefone_Residencial,
                        entity.Email,
                        entity.CEP,
                        entity.Endereco_Rua,
                        entity.Endereco_Numero,
                        entity.Endereco_Bairro,
                        entity.Endereco_Cidade,
                        entity.Endereco_Estado,
                        entity.Estado_Civil,
                        entity.Filhos,
                        entity.Qnt_Filhos,
                        entity.Escolaridade,
                        entity.Departamento,
                        entity.Ativo,
                        entity.Salario
                    }); ;
            });
        }

        public async Task<IEnumerable<Colaborador>> GetAllColaboradores()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Colaborador>("SP_SEL_COLABORADOR");
                return query;
            });
        }

        public async ValueTask<Colaborador> GetColaboradorById(string CPF)
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Colaborador>("SP_SEL_COLABORADOR_CPF @CPF",
                    new { CPF = CPF });
                return query;
            });
        }

        public async Task RemoveColaborador(string CPF)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_DEL_COLABORADOR_CPF @CPF", new { CPF = CPF });
            });
        }

        public async Task UpdateColaborador(Colaborador entity)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_UPD_COLABORADOR @Nome,@CPF,@Dt_Nascimento,@Telefone_Celular, @Telefone_Residencial,@Email, @CEP, @Endereco_Rua, @Endereco_Numero,@Endereco_Bairro," +
                    " @Endereco_Cidade,@Endereco_Estado,@Estado_Civil,@Filhos,@Qnt_Filhos,@Escolaridade,@Departamento,@Ativo,@Salario",
                    new
                    {
                        entity.Nome,
                        entity.CPF,
                        entity.Dt_Nascimento,
                        entity.Telefone_Celular,
                        entity.Telefone_Residencial,
                        entity.Email,
                        entity.CEP,
                        entity.Endereco_Rua,
                        entity.Endereco_Numero,
                        entity.Endereco_Bairro,
                        entity.Endereco_Cidade,
                        entity.Endereco_Estado,
                        entity.Estado_Civil,
                        entity.Filhos,
                        entity.Qnt_Filhos,
                        entity.Escolaridade,
                        entity.Departamento,
                        entity.Ativo,
                        entity.Salario
                    });
            });
        }
    }
}
