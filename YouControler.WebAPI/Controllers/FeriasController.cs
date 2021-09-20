using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;
using YouControler.WebAPI.Services.Interfaces;

namespace YouControler.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeriasController : Controller
    {
        private readonly IFeriasRepository _feriasRepository;

        public FeriasController(IFeriasRepository feriasRepository)
        {
            _feriasRepository = feriasRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ferias>>> GetAllFerias()
        {
            var products = await _feriasRepository.GetAllFerias();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Ferias>>> GetFeriasById(int id)
        {
            var product = await _feriasRepository.GetFeriasById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> AddFerias([FromBody] Ferias entity)
        {
            await _feriasRepository.AddFerias(entity);
            return Ok(entity);
        }

        [HttpPut]
        public async Task<ActionResult<Ferias>> UpdateFerias([FromBody] Ferias entity)
        {
            await _feriasRepository.UpdateFerias(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveFerias(int id)
        {
            await _feriasRepository.RemoveFerias(id);
            return Ok();
        }
    }
}
