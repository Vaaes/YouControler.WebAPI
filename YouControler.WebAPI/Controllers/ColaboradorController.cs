using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;
using YouControler.WebAPI.Services.Interfaces;

namespace YouControler.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColaboradorController : Controller
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorController(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Colaborador>> GetAllColaboradores()
        {
            var products = await _colaboradorRepository.GetAllColaboradores();
            return Ok(products);
        }

        [HttpGet]
        [Route("{CPF}")]
        [Authorize]
        public async Task<ActionResult<Colaborador>> GetColaboradorById(string CPF)
        {
            var product = await _colaboradorRepository.GetColaboradorById(CPF);
            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddColaborador(Colaborador entity)
        {
            await _colaboradorRepository.AddColaborador(entity);
            return Ok(entity);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Colaborador>> UpdateColaborador(Colaborador entity)
        {
            await _colaboradorRepository.UpdateColaborador(entity);
            return Ok(entity);
        }

        [HttpDelete("{CPF}")]
        [Authorize]
        public async Task<ActionResult> RemoveColaborador(string CPF)
        {
            await _colaboradorRepository.RemoveColaborador(CPF);
            return Ok();
        }
    }
}