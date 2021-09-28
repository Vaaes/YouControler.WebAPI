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
    public class ColaboradorRepository : BaseRepository, IColaboradorRepository
    {
        public ColaboradorRepository(IConfiguration configuration) : base(configuration) { }

        public async Task AddColaborador(Colaborador entity)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Nome", value: (object)entity.Nome ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@CPF", value: (object)entity.CPF ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Dt_Nascimento", value: (object)entity.Dt_Nascimento ?? DBNull.Value, dbType: DbType.Date);
            args.Add(name: "@Telefone_Celular", value: (object)entity.Telefone_Celular ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Telefone_Residencial", value: (object)entity.Telefone_Residencial ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Email", value: (object)entity.Email ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@CEP", value: (object)entity.CEP ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Endereco_Rua", value: (object)entity.Endereco_Rua ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Endereco_Numero", value: (object)entity.Endereco_Numero ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Endereco_Bairro", value: (object)entity.Endereco_Bairro ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Endereco_Cidade", value: (object)entity.Endereco_Cidade ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Endereco_Estado", value: (object)entity.Endereco_Estado ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Estado_Civil", value: (object)entity.Estado_Civil ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Filhos", value: (object)entity.Filhos ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@Qnt_Filhos", value: (object)entity.Qnt_Filhos ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Escolaridade", value: (object)entity.Escolaridade ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Departamento", value: (object)entity.Departamento ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Ativo", value: (object)entity.Ativo ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@Salario", value: (object)entity.Salario ?? DBNull.Value, dbType: DbType.String);

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_INS_COLABORADOR @Nome,@CPF,@Dt_Nascimento,@Telefone_Celular, @Telefone_Residencial,@Email, @CEP, @Endereco_Rua, @Endereco_Numero,@Endereco_Bairro," +
                    " @Endereco_Cidade,@Endereco_Estado,@Estado_Civil,@Filhos,@Qnt_Filhos,@Escolaridade,@Departamento,@Ativo,@Salario", args);
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
            var args = new DynamicParameters(new { });
            args.Add(name: "@CPF", value: (object)CPF ?? DBNull.Value, dbType: DbType.Int32);
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Colaborador>("SP_SEL_COLABORADOR_CPF @CPF", CPF);
                return query;
            });
        }

        public async Task RemoveColaborador(string CPF)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@CPF", value: (object)CPF ?? DBNull.Value, dbType: DbType.Int32);
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_DEL_COLABORADOR_CPF @CPF", args);
            });
        }

        public async Task UpdateColaborador(Colaborador entity)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)entity.Id ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@Nome", value: (object)entity.Nome ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@CPF", value: (object)entity.CPF ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Dt_Nascimento", value: (object)entity.Dt_Nascimento ?? DBNull.Value, dbType: DbType.Date);
            args.Add(name: "@Telefone_Celular", value: (object)entity.Telefone_Celular ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Telefone_Residencial", value: (object)entity.Telefone_Residencial ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Email", value: (object)entity.Email ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@CEP", value: (object)entity.CEP ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Endereco_Rua", value: (object)entity.Endereco_Rua ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Endereco_Numero", value: (object)entity.Endereco_Numero ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Endereco_Bairro", value: (object)entity.Endereco_Bairro ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Endereco_Cidade", value: (object)entity.Endereco_Cidade ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Endereco_Estado", value: (object)entity.Endereco_Estado ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Estado_Civil", value: (object)entity.Estado_Civil ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Filhos", value: (object)entity.Filhos ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@Qnt_Filhos", value: (object)entity.Qnt_Filhos ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Escolaridade", value: (object)entity.Escolaridade ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Departamento", value: (object)entity.Departamento ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Ativo", value: (object)entity.Ativo ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@Salario", value: (object)entity.Salario ?? DBNull.Value, dbType: DbType.String);

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_UPD_COLABORADOR @Id, @Nome,@CPF,@Dt_Nascimento,@Telefone_Celular, @Telefone_Residencial,@Email, @CEP, @Endereco_Rua, @Endereco_Numero,@Endereco_Bairro," +
                    " @Endereco_Cidade,@Endereco_Estado,@Estado_Civil,@Filhos,@Qnt_Filhos,@Escolaridade,@Departamento,@Ativo,@Salario", args);
            });
        }
    }
}
