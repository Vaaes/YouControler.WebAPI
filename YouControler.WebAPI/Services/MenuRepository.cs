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
    public class MenuRepository : BaseRepository, IMenuRepository
    {
        public MenuRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<IEnumerable<Menus>> GetAllMenu()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Menus>("SP_SEL_MENU");
                return query;
            });
        }

        public async ValueTask<Menus> GetMenuById(int id)
        {
            var args = new DynamicParameters(new { });
            args.Add(name: "@Id", value: (object)id ?? DBNull.Value, dbType: DbType.Int32);
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Menus>("SP_SEL_MENU_ID @Id", args);
                return query;
            });
        }
    }
}
