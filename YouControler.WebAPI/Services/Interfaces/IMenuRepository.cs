using System.Collections.Generic;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;

namespace YouControler.WebAPI.Services.Interfaces
{
    public interface IMenuRepository
    {
        ValueTask<Menus> GetMenuById(int id);
        Task<IEnumerable<Menus>> GetAllMenu();
    }
}
