using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;
using YouControler.WebAPI.Services.Interfaces;
using YouControler.WebAPI.Services.Token;

namespace YouControler.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LogInController : Controller
    {
        private readonly ILogInRepository _logInRepository;

        public LogInController(ILogInRepository logInRepository)
        {
            _logInRepository = logInRepository;
        }

        [HttpPost]
        [Route("Auth")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Usuario model)
        {
            var user = await _logInRepository.VerificaAcesso(model.Login, model.Senha);

            Perfil model2 = new Perfil();
            model2.Role = "Administrador";

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            model.Senha = "";

            return new
            {
                Id = user.Id,
                Nome = user.Nome,
                IdNivelAcesso = user.IdNivelAcesso,
                token = token
            };
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ControleAcesso>>> GetControleAcesso(int id)
        {
            Perfil model = new Perfil();
            model.Role = "Usuario";
            var product = await _logInRepository.GetAllControleAcesso(id);
            return Ok(product);
        }
    }
}
