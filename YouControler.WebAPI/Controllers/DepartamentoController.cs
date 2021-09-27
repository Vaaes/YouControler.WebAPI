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
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoController(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetAllDepartamentos()
        {
            var products = await _departamentoRepository.GetAllDepartamentos();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamentoById(int id)
        {
            var product = await _departamentoRepository.GetDepartamentoById(id);
            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddDepartamento([FromBody] Departamento entity)
        {
            await _departamentoRepository.AddDepartamento(entity);
            return Ok(entity);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Cargo>> UpdateDepartamento([FromBody] Departamento entity)
        {
            await _departamentoRepository.UpdateDepartamento(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> RemoveDepartamento(int id)
        {
            await _departamentoRepository.RemoveDepartamento(id);
            return Ok();
        }

    }
}
