﻿using Dapper;
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
    public class FuncionarioRepository : BaseRepository, IFuncionarioRepository
    {
        public FuncionarioRepository(IConfiguration configuration) : base(configuration) { }

        public async Task AddUFuncionario(Funcionario entity)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Nome", value: (object)entity.Nome ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@CPF", value: (object)entity.CPF ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Tipo", value: (object)entity.Tipo ?? DBNull.Value, dbType: DbType.DateTime);
            args.Add(name: "@Email", value: (object)entity.Email ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Salario", value: (object)entity.Salario ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@IdCargo", value: (object)entity.IdCargo ?? DBNull.Value, dbType: DbType.String);

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SPA_INS_FUNCIONARIO @IdNivelAcesso, @Nome, @CPF, @Tipo, @Email, @Salario, @IdCargo", args);
            });
        }

        public async Task<IEnumerable<Funcionario>> GetAllFuncionario()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Funcionario>("SPA_SEL_FUNCIONARIO");
                return query;
            });
        }

        public async Task<IEnumerable<Funcionario>> GetFuncionariooByParam(int? id = null, string nome = null, string CPF = null, string Tipo = null, string email = null, string Salario = null, int? IdCargo = null)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@ID", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@Nome", value: (object)nome ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@IdNivelAcesso", value: (object)CPF ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@CPF", value: (object)Tipo ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Email", value: (object)email ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Usuario", value: (object)Salario ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Usuario", value: (object)IdCargo ?? DBNull.Value, dbType: DbType.Int32);

            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Funcionario>("SPA_SEL_FUNCIONARIO @ID, @Nome, @IdNivelAcesso, @CPF, @Email, @Usuario", args);
                return query;
            });
        }

        public async Task RemoveFuncionario(int id)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SPA_DEL_FUNCIONARIO @ID", args);
            });
        }

        public async Task UpdateFuncionario(Funcionario entity)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)entity.Id ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@Nome", value: (object)entity.Nome ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@CPF", value: (object)entity.CPF ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Tipo", value: (object)entity.Tipo ?? DBNull.Value, dbType: DbType.DateTime);
            args.Add(name: "@Email", value: (object)entity.Email ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Salario", value: (object)entity.Salario ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@IdCargo", value: (object)entity.IdCargo ?? DBNull.Value, dbType: DbType.String);

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SPA_UPD_FUNCIONARIO @Id, @IdNivelAcesso, @Nome, @CPF, @Tipo, @Email, @Salario, @IdCargo", args);
            });
        }
    }
}
