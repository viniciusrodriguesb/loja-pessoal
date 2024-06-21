using Application.DTO.Request;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> CriarUsuario(NovoUsuarioRequest request)
        {
            try
            {
                var result = await _usuarioService.CriarUsuario(request);

                return StatusCode(200, result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, ex);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro de serviço");
            }
        }

        [HttpGet("buscar-usuario/{id}")]
        public async Task<IActionResult> BuscarUsuario(int id)
        {
            try
            {
                var result = await _usuarioService.ListarInformacoesUsuario(id);

                if (result == null)
                    return StatusCode(204);

                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro de serviço");
            }
        }
        [HttpPut("editar-usuario")]
        public async Task<IActionResult> EditarUsuario([FromBody] UsuarioEditadoRequest request, [FromQuery] int Id)
        {
            try
            {
                var result = await _usuarioService.EditarUsuario(request, Id);

                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro de serviço");
            }
        }
    }
}
