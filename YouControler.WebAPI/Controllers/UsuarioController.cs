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
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAllUsuario()
        {
            var products = await _usuarioRepository.GetAllUsuario();
            return Ok(products);
        }

        [HttpGet]
        [Route("GetUsuarioByParam")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarioById(int? id = null, string nome = null, int? IdNivelAcesso = null, string cpf = null, string email = null, string usuario = null)
        {
            var product = await _usuarioRepository.GetUsuarioById(id, nome, IdNivelAcesso, cpf, email, usuario);
            return Ok(product);
        }

        [HttpGet]
        [Route("GetVerificaPerfil")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarioById(int IdNivelAcesso)
        {
            var product = await _usuarioRepository.GetVerificaPerfil(IdNivelAcesso);
            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddUsuario([FromBody] Usuario entity)
        {
            await _usuarioRepository.AddUsuario(entity);
            return Ok(entity);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Usuario>> UpdateUsuario([FromBody] Usuario entity)
        {
            await _usuarioRepository.UpdateUsuario(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> RemoveUsuario(int id)
        {
            await _usuarioRepository.RemoveUsuario(id);
            return Ok();
        }
    }
}
