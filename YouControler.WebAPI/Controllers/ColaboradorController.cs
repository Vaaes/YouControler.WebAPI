﻿using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Administrador,Gerente")]
        public async Task<ActionResult<Colaborador>> GetAllColaboradores()
        {
            var products = await _colaboradorRepository.GetAllColaboradores();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Administrador,Gerente")]
        public async Task<ActionResult<Colaborador>> GetColaboradorById(int id)
        {
            var product = await _colaboradorRepository.GetColaboradorById(id);
            return Ok(product);
        }

        [HttpPost]
        [Authorize(Roles = "Administrador,Gerente")]
        public async Task<ActionResult> AddColaborador(Colaborador entity)
        {
            await _colaboradorRepository.AddColaborador(entity);
            return Ok(entity);
        }

        [HttpPut]
        [Authorize(Roles = "Administrador,Gerente")]
        public async Task<ActionResult<Colaborador>> UpdateColaborador(Colaborador entity)
        {
            await _colaboradorRepository.UpdateColaborador(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador,Gerente")]
        public async Task<ActionResult> RemoveColaborador(int id)
        {
            await _colaboradorRepository.RemoveColaborador(id);
            return Ok();
        }
    }
}