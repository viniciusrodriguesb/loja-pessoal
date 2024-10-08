﻿using Application.Services;
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

        [HttpPost("autenticar")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] int Id)
        {
            var usuario = await _usuarioService.ListarInformacoesUsuario(Id);

            if (usuario == null) 
                return NotFound();

            var token = _tokenService.GerarToken();

            return new
            {
                User = usuario,
                Token = token
            };

        }
    }
}
