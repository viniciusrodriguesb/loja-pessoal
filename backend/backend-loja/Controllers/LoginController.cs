using Application.DTO.Request;
using Application.Logger;
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
        private readonly ILogger<LoginController> _logger;
        public LoginController(UsuarioService usuarioService,
                               TokenService tokenService,
                               ILogger<LoginController> logger)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
            _logger = logger;
        }
        #endregion

        [HttpPost("logar")]
        public async Task<IActionResult> Logar([FromBody] LoginRequest login)
        {
            try
            {
                _logger.Iniciando("Logar");

                var result = await _usuarioService.Logar(login);

                if (result == null)
                    return StatusCode(StatusCodes.Status401Unauthorized);

                _logger.Finalizado("Logar");

                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                _logger.Erro("Logar", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
            }
        }
    }
}
