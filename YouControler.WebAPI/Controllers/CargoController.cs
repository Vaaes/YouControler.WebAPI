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
    public class CargoController : Controller
    {
        private readonly ICargoRepository _cargoRepository;

        public CargoController(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Cargo>>> GetAllCargos()
        {
            var products = await _cargoRepository.GetAllCargos();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Cargo>>> GetCargoById(int id)
        {
            var product = await _cargoRepository.GetCargoById(id);
            return Ok(product);
        }

        //[HttpGet("{Nome}")]
        [HttpGet]
        [Route("GetCargoByName")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Cargo>>> GetCargoName(string Nome)
        {
            var product = await _cargoRepository.GetCargoName(Nome);
            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddCargo([FromBody] Cargo entity)
        {
            await _cargoRepository.AddCargo(entity);
            return Ok(entity);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Cargo>> UpdateCargo([FromBody] Cargo entity)
        {
            await _cargoRepository.UpdateCargo(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> RemoveCargo(int id)
        {
            await _cargoRepository.RemoveCargo(id);
            return Ok();
        }
    }
}
