using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste_API.Dto.Usuario;
using Teste_API.Services.AuthService;

namespace Teste_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthInterface _authInterface;

        public AuthController(IAuthInterface authInterface)
        {
            _authInterface = authInterface;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UsuarioLoginDto usuarioLogin)
        {
            var resposta = await _authInterface.Login(usuarioLogin);
            return Ok(resposta);
        }

        [HttpPost("Registrar")]
        public async Task<ActionResult> Registrar(UsuarioCriacaoDto usuarioRegistro)
        {
            var resposta = await _authInterface.Registrar(usuarioRegistro);
            return Ok(resposta);
        }

    }
}
