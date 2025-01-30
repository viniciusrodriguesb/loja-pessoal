using Application.DTO.Request;
using Application.Logger;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

        [SwaggerOperation(Summary = "Login com retorno do token de serviço")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
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
            catch (UnauthorizedAccessException ex)
            {
                _logger.Erro("Não autorizado", ex);
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
            catch (Exception ex)
            {
                _logger.Erro("Logar", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
            }
        }
    }
}
