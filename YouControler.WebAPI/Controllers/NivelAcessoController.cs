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
    public class NivelAcessoController : Controller
    {
        private readonly INivelAcessoRepository _nivelAcessoRepository;

        public NivelAcessoController(INivelAcessoRepository nivelAcessoRepository)
        {
            _nivelAcessoRepository = nivelAcessoRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<NivelAcesso>>> GetAllPerfilAcesso()
        {
            var products = await _nivelAcessoRepository.GetAllNivelAcesso();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<NivelAcesso>>> GetNivelAcessoById(int id)
        {
            var product = await _nivelAcessoRepository.GetNivelAcessoById(id);
            return Ok(product);
        }

        [HttpGet("{role}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<NivelAcesso>>> GetNivelAcessoByRole(string Role)
        {
            var product = await _nivelAcessoRepository.GetNivelAcessoByRole(Role);
            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddNivelAcesso([FromBody] NivelAcesso entity)
        {
            await _nivelAcessoRepository.AddNivelAcesso(entity);
            return Ok(entity);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<NivelAcesso>> UpdateNivelAcesso([FromBody] NivelAcesso entity)
        {
            await _nivelAcessoRepository.UpdateNivelAcesso(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> RemoveNivelAcesso(int id)
        {
            await _nivelAcessoRepository.RemoveNivelAcesso(id);
            return Ok();
        }
    }
}
