using Application.DTO.Request;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Inicializadores e Construtor
        private readonly UsuarioService _usuarioService;
        private readonly TokenService _tokenService;
        public LoginController(UsuarioService usuarioService,
                               TokenService tokenService)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
        }
        #endregion

        [HttpPost("logar")]
        public async Task<IActionResult> Logar([FromBody] LoginRequest login)
        {
            try
            {
                var result = await _usuarioService.Logar(login);

                if (result == null)
                    return StatusCode(StatusCodes.Status401Unauthorized);

                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
            }
        }
    }
}
