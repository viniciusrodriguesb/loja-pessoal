using Application.DTO.Request;
using Application.Logger;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        #region Inicializadores e Construtor
        private readonly UsuarioService _usuarioService;
        private readonly ILogger<UsuarioController> _logger;
        public UsuarioController(UsuarioService usuarioService, ILogger<UsuarioController> logger)
        {
            _usuarioService = usuarioService;
            _logger = logger;
        }
        #endregion

        [HttpPost("criar")]
        public async Task<IActionResult> CriarUsuario(NovoUsuarioRequest request)
        {
            try
            {
                _logger.Iniciando("CriarUsuario");

                var result = await _usuarioService.CriarUsuario(request);

                _logger.Finalizado("CriarUsuario");

                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (ArgumentException ex)
            {
                _logger.Erro("CriarUsuario", ex);
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
            catch (Exception ex)
            {
                _logger.Erro("CriarUsuario", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
            }
        }
        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarUsuario(int id)
        {
            try
            {
                _logger.Iniciando("BuscarUsuario");

                var result = await _usuarioService.BuscarUsuarioId(id);

                if (result == null)
                    return StatusCode(StatusCodes.Status204NoContent, "Usuario não encontrado.");

                _logger.Finalizado("BuscarUsuario");

                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                _logger.Erro("BuscarUsuario", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
            }
        }
        [Authorize]
        [HttpPut("editar")]
        public async Task<IActionResult> EditarUsuario([FromBody] UsuarioEditadoRequest request, [FromQuery] int Id)
        {
            try
            {
                _logger.Iniciando("EditarUsuario");

                var result = await _usuarioService.EditarUsuario(request, Id);

                _logger.Finalizado("EditarUsuario");

                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                _logger.Erro("EditarUsuario", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
            }
        }
        [Authorize]
        [HttpDelete("deletar")]
        public async Task<IActionResult> DeletarUsuario([FromBody] int Id)
        {
            try
            {
                _logger.Iniciando("DeletarUsuario");

                var result = await _usuarioService.DeletarUsuario(Id);

                _logger.Finalizado("DeletarUsuario");

                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                _logger.Erro("DeletarUsuario", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro de serviço");
            }
        }
    }
}
