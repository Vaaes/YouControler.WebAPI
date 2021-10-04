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
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetAllFuncionario()
        {
            var products = await _funcionarioRepository.GetAllFuncionario();
            return Ok(products);
        }

        [HttpGet]
        [Route("GetFuncionarioByParam")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionariooByParam(int? id = null, string nome = null, string CPF = null, string Tipo = null, string email = null, string Salario = null, int? IdCargo = null)
        {
            var product = await _funcionarioRepository.GetFuncionariooByParam(id, nome, CPF, Tipo, email, Salario, IdCargo);
            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddUFuncionario([FromBody] Funcionario entity)
        {
            await _funcionarioRepository.AddUFuncionario(entity);
            return Ok(entity);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Funcionario>> UpdateFuncionario([FromBody] Funcionario entity)
        {
            await _funcionarioRepository.UpdateFuncionario(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> RemoveFuncionario(int id)
        {
            await _funcionarioRepository.RemoveFuncionario(id);
            return Ok();
        }

    }
}
