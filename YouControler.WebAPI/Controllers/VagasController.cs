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
    public class VagasController : Controller
    {
        private readonly IVagasRepository _vagasRepository;

        public VagasController(IVagasRepository vagasRepository)
        {
            _vagasRepository = vagasRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Vagas>>> GetAllCandidatos()
        {
            var products = await _vagasRepository.GetAllVagas();
            return Ok(products);
        }

        [HttpGet]
        [Route("GetVagasByParam")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Vagas>>> GetVagasByParam(int? id = null, string NomeVaga = null, string DataMaxima = null, string PerfilVaga = null)
        {
            var product = await _vagasRepository.GetVagasByParam(id, NomeVaga, DataMaxima, PerfilVaga);
            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddVaga([FromBody] Vagas entity)
        {
            await _vagasRepository.AddVaga(entity);
            return Ok(entity);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Vagas>> UpdateVaga([FromBody] Vagas entity)
        {
            await _vagasRepository.UpdateVaga(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> RemoveVaga(int id)
        {
            await _vagasRepository.RemoveVaga(id);
            return Ok();
        }
    }
}
