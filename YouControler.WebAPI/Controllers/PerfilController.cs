using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;
using YouControler.WebAPI.Services.Interfaces;

namespace YouControler.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerfilController : Controller
    {
        private readonly IPerfilRepository _nivelAcessoRepository;

        public PerfilController(IPerfilRepository nivelAcessoRepository)
        {
            _nivelAcessoRepository = nivelAcessoRepository;
        }

        [HttpGet]
        [Route("Get")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Perfil>>> GetAllPerfilAcesso(int? id, string role = null)
        {
            var products = await _nivelAcessoRepository.GetPerfilAcesso(id, role);
            return Ok(products);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddPerfilAcesso([FromBody] Perfil entity)
        {
            await _nivelAcessoRepository.AddPerfilAcesso(entity);
            return Ok(entity);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Usuario>> UpdatePerfilAcesso([FromBody] Perfil entity)
        {
            await _nivelAcessoRepository.UpdatePerfilAcesso(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> RemovePerfilAcesso(int id)
        {
            await _nivelAcessoRepository.RemovePerfilAcesso(id);
            return Ok();
        }
    }
}
