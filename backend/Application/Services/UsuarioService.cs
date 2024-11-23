using Application.Constantes.Enums;
using Application.DTO.Request;
using Application.DTO.Response;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class UsuarioService
    {

        #region Inicializadores e Construtor
        private readonly ILogger<UsuarioService> _logger;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogUsuarioRepository _logUsuarioRepository;
        public UsuarioService(
               IUsuarioRepository usuarioRepository,
               ILogUsuarioRepository logUsuarioRepository,
               ILogger<UsuarioService> logger)
        {
            _logUsuarioRepository = logUsuarioRepository;
            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }
        #endregion

        public async Task<string> Logar(LoginRequest login)
        {
            if (login == null || string.IsNullOrEmpty(login.Usuario) || string.IsNullOrEmpty(login.Senha))
                throw new ArgumentNullException("LoginRequest", "Os dados de login são inválidos.");

            try
            {
                var usuario = await _usuarioRepository.BuscarUsuario(login.Usuario);

                var senhaValida = BCrypt.Net.BCrypt.Verify(login.Senha, usuario.CoSenha);

                if (!senhaValida || usuario == null)
                    throw new UnauthorizedAccessException("Acesso negado, tente novamente.");

                var token = TokenService.GerarToken();

                return token;
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException("Falha na autenticação: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro: " + ex.Message);
            }
        }
        public async Task CriarUsuario(NovoUsuarioRequest request)
        {
            try
            {
                if (request == null)
                    new ArgumentException("Dados da requisição vazios, preencha novamente.");

                request.Senha = BCrypt.Net.BCrypt.HashPassword(request.Senha);

                await _usuarioRepository.CriarUsuario(request.Usuario, request.Email, request.Senha);

                var usuarioCriado = await _usuarioRepository.BuscarUsuario(request.Usuario);

                await _logUsuarioRepository.GerarLog(usuarioCriado, (short)TipoOperacao.INSERCAO);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro: " + ex.Message);
            }
        }
        public async Task<UsuarioResponse> BuscarUsuarioId(int Id)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioId(Id);

            var response = new UsuarioResponse()
            {
                Email = usuario.NoEmail,
                Senha = usuario.CoSenha,
                Usuario = usuario.NoUsuario
            };

            return response;
        }
        public async Task EditarUsuario(UsuarioEditadoRequest request, int Id)
        {
            try
            {
                var usuario = await _usuarioRepository.BuscarUsuarioId(Id);
                if (usuario == null)
                    throw new ArgumentException("EditarUsuario: Usuário não encontrado");

                await _usuarioRepository.AlterarUsuario(usuario, request.NovoUsuario, request.NovaSenha, request.NovoEmail);
                await _logUsuarioRepository.GerarLog(usuario, (short)TipoOperacao.EDICAO);

            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"EditarUsuario: Erro ao atualizar a entidade: {ex}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EditarUsuario: Erro {ex}");
                throw;
            }
        }
        public async Task DeletarUsuario(int Id)
        {
            try
            {
                var usuario = await _usuarioRepository.BuscarUsuarioId(Id);
                if (usuario == null)
                    throw new ArgumentException("Usuário não encontrado.");

                await _usuarioRepository.Remover(usuario);
                await _logUsuarioRepository.GerarLog(usuario, (short)TipoOperacao.DELECAO);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"DeletarUsuario: Erro {ex}");
                throw;
            }
        }
    }
}
