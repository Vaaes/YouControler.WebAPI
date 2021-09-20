using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;
using YouControler.WebAPI.Services.Interfaces;

namespace YouControler.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NivelAcessoController : Controller
    {
        private readonly INivelAcessoRepository _nivelAcessoRepository;

        public NivelAcessoController(INivelAcessoRepository nivelAcessoRepository)
        {
            _nivelAcessoRepository = nivelAcessoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NivelAcesso>>> GetAllNivelAcesso()
        {
            var products = await _nivelAcessoRepository.GetAllNivelAcesso();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<NivelAcesso>>> GetNivelAcessoById(int id)
        {
            var product = await _nivelAcessoRepository.GetNivelAcessoById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> AddNivelAcesso([FromBody] NivelAcesso entity)
        {
            await _nivelAcessoRepository.AddNivelAcesso(entity);
            return Ok(entity);
        }

        [HttpPut]
        public async Task<ActionResult<Usuario>> UpdateNivelAcesso([FromBody] NivelAcesso entity)
        {
            await _nivelAcessoRepository.UpdateNivelAcesso(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveNivelAcesso(int id)
        {
            await _nivelAcessoRepository.RemoveNivelAcesso(id);
            return Ok();
        }
    }
}
