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
    public class CandidatosController : Controller
    {
        private readonly ICandidatosRepository _candidatoRepository;

        public CandidatosController(ICandidatosRepository candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Candidatos>>> GetAllCandidatos()
        {
            var products = await _candidatoRepository.GetAllCandidatos();
            return Ok(products);
        }

        [HttpGet]
        [Route("GetCandidatosByParam")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Candidatos>>> GetCandidatosByParam(string NomeCandidato = null, string EmailCandidato = null)
        {
            var product = await _candidatoRepository.GetCandidatosByParam(NomeCandidato, EmailCandidato);
            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddCandidato([FromBody] Candidatos entity)
        {
            await _candidatoRepository.AddCandidato(entity);
            return Ok(entity);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Candidatos>> UpdateCandidato([FromBody] Candidatos entity)
        {
            await _candidatoRepository.UpdateCandidato(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> RemoveCandidato(int id)
        {
            await _candidatoRepository.RemoveCandidato(id);
            return Ok();
        }
    }
}
