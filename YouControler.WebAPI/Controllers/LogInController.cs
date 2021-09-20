using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]Usuario model)
        {
            var user = _logInRepository.VerificaAcesso(model.Login, model.Senha);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user.Result);
            model.Senha = "";

            return new
            {
                user = user,
                token = token
            };
        }
    }
}
