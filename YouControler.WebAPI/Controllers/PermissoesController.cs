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
    public class PermissoesController : Controller
    {
        private readonly IPermissoesRepository _permissoesRepository;
        public PermissoesController(IPermissoesRepository permissoesRepository)
        {
            _permissoesRepository = permissoesRepository;
        }

        [HttpGet("{id}/{idmenu}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Permissoes>>> HasPermission(int id, int IdMenu)
        {
            var product = await _permissoesRepository.HasPermission(id, IdMenu);
            return Ok(product);
        }
        [HttpGet()]
        [Route("GetByProfile/{IdPerfilAcesso}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Permissoes>>> GetPermissionByProfile(int IdPerfilAcesso)
        {
            var product = await _permissoesRepository.GetPermissionByProfile(IdPerfilAcesso);
            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddPermissoes([FromBody] Permissoes entity)
        {
            await _permissoesRepository.AddPermissoes(entity);
            return Ok(entity);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Permissoes>> UpdatePermissoes([FromBody] Permissoes entity)
        {
            await _permissoesRepository.UpdatePermissoes(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> RemovePermissoes(int id)
        {
            await _permissoesRepository.RemovePermissoes(id);
            return Ok();
        }
    }
}
