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
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        public UsuarioRepository(IConfiguration configuration) : base(configuration) { }

        public async Task AddUsuario(Usuario entity)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@IdNivelAcesso", value: (object)entity.IdNivelAcesso ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@Nome", value: (object)entity.Nome ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@CPF", value: (object)entity.CPF ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Nascimento", value: (object)entity.Nascimento ?? DBNull.Value, dbType: DbType.DateTime);
            args.Add(name: "@Telefone_Celular", value: (object)entity.Telefone_Celular ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Telefone_Residencial", value: (object)entity.Telefone_Residencial ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Email", value: (object)entity.Email ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@CEP", value: (object)entity.CEP ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Login", value: (object)entity.Login ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Senha", value: (object)entity.Senha ?? DBNull.Value, dbType: DbType.String);

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_INS_USUARIO @IdNivelAcesso, @Nome, @CPF, @Nascimento, @Telefone_Celular, @Telefone_Residencial, @Email, @CEP, @Login, @Senha", args);
            });
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuario()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Usuario>("SP_SEL_USUARIO");
                return query;
            });
        }

        public async Task<IEnumerable<Usuario>> GetUsuarioById(int? id = null, string nome = null, int? IdNivelAcesso = null, string cpf = null, string email = null, string usuario = null)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@ID", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@Nome", value: (object)nome ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@IdNivelAcesso", value: (object)IdNivelAcesso ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@CPF", value: (object)cpf ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Email", value: (object)email ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Usuario", value: (object)usuario ?? DBNull.Value, dbType: DbType.String);

            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Usuario>("SP_SEL_USUARIO_ID @ID, @Nome, @IdNivelAcesso, @CPF, @Email, @Usuario", args);
                return query;
            });
        }
        

        public async Task<IEnumerable<Usuario>> GetVerificaPerfil(int IdNivelAcesso)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@IdNivelAcesso", value: (object)IdNivelAcesso ?? DBNull.Value, dbType: DbType.Int32);

            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Usuario>("SP_SEL_USUARIO_VERIFICA_PERFIL @IdNivelAcesso", args);
                return query;
            });
        }

        public async Task RemoveUsuario(int id)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_DEL_USUARIO @ID", args);
            });
        }

        public async Task UpdateUsuario(Usuario entity)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)entity.Id ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@IdNivelAcesso", value: (object)entity.IdNivelAcesso ?? DBNull.Value, dbType: DbType.Int32);
            args.Add(name: "@Nome", value: (object)entity.Nome ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@CPF", value: (object)entity.CPF ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Nascimento", value: (object)entity.Nascimento ?? DBNull.Value, dbType: DbType.DateTime);
            args.Add(name: "@Telefone_Celular", value: (object)entity.Telefone_Celular ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Telefone_Residencial", value: (object)entity.Telefone_Residencial ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Email", value: (object)entity.Email ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@CEP", value: (object)entity.CEP ?? DBNull.Value, dbType: DbType.String);
            args.Add(name: "@Login", value: (object)entity.Login ?? DBNull.Value, dbType: DbType.String);

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync("SP_UPD_USUARIO @Id, @IdNivelAcesso, @Nome, @CPF, @Nascimento, @Telefone_Celular, @Telefone_Residencial, @Email, @CEP, @Login", args);
            });
        }
    }
}
