using Application.DTO.Request;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly TokenService _tokenService;
        public LoginController(UsuarioService usuarioService,
                               TokenService tokenService)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
        }

        [HttpPost("autenticar")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UsuarioRequest request)
        {
            var usuario = await _usuarioService.BuscarUsuario(request);

            if (usuario == null) 
                return NotFound();

            var token = _tokenService.GerarToken(usuario);

            return new
            {
                Useer = usuario,
                Token = token
            };

        }
    }
}
