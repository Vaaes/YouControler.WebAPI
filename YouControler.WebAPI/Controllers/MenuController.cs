using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;
using YouControler.WebAPI.Services.Interfaces;

namespace YouControler.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : Controller
    {
        private readonly IMenuRepository _menuRepository;

        public MenuController(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Menus>>> GetAllMenu()
        {
            var products = await _menuRepository.GetAllMenu();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Menus>>> GetMenuById(int id)
        {
            var product = await _menuRepository.GetMenuById(id);
            return Ok(product);
        }

        [HttpGet]
        [Route("GetByProfile/{IdPerfilAcesso}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Menus>>> GetMenuNivelAcessoByProfile(int IdPerfilAcesso)
        {
            var product = await _menuRepository.GetMenuNivelAcessoByProfile(IdPerfilAcesso);
            return Ok(product);
        }
    }
}
