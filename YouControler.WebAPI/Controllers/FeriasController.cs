﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [Authorize]
        public async Task<ActionResult<IEnumerable<Ferias>>> GetAllFerias()
        {
            var products = await _feriasRepository.GetAllFerias();
            return Ok(products);
        }

        [HttpGet]
        [Route("GetByParam")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Ferias>>> GetFeriasByParam(int? Id = null, string Data_Inicio = null, string Data_Final = null, int? IdUsuario = null, bool? Aprovado = null)
        {
            var product = await _feriasRepository.GetFeriasByParam(Data_Inicio, Data_Final, Id, IdUsuario, Aprovado);
            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddFerias([FromBody] Ferias entity)
        {
            await _feriasRepository.AddFerias(entity);
            return Ok(entity);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Ferias>> UpdateFerias([FromBody] Ferias entity)
        {
            await _feriasRepository.UpdateFerias(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> RemoveFerias(int id)
        {
            await _feriasRepository.RemoveFerias(id);
            return Ok();
        }
    }
}
