using Application.Constantes.Enums;
using Application.DTO.LogDTO;
using Application.DTO.Request;
using Application.DTO.Response;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class UsuarioService
    {
        #region Inicializadores e Construtor
        private readonly LogService _logService;
        private readonly ILogger<UsuarioService> _logger;
        private readonly DbContextBase _dbContext;
        private readonly TokenService _tokenService;
        public UsuarioService(
               TokenService tokenService,
               LogService logService,
               DbContextBase dbContext,
               ILogger<UsuarioService> logger)
        {
            _logService = logService;
            _dbContext = dbContext;
            _logger = logger;
            _tokenService = tokenService;
        }
        #endregion

        public async Task<string> Logar(LoginRequest login)
        {
            if (login == null || string.IsNullOrEmpty(login.Usuario) || string.IsNullOrEmpty(login.Senha))
                throw new ArgumentNullException("LoginRequest", "Os dados de login são inválidos.");

            try
            {
                var usuario = await _dbContext.TB001_USUARIO.AsNoTracking()
                                                            .Where(x => x.NoUsuario == login.Usuario)
                                                            .FirstOrDefaultAsync();

                var senhaValida = BCrypt.Net.BCrypt.Verify(login.Senha, usuario.CoSenha);

                if (!senhaValida)
                    throw new UnauthorizedAccessException("Senha inválida, tente novamente.");

                if (usuario == null)
                    throw new UnauthorizedAccessException("Usuário não encontrado.");

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

        public async Task<bool> CriarUsuario(NovoUsuarioRequest request)
        {
            bool criou = false;

            if (request == null)
                new ArgumentException("Dados da requisição vazios, preencha novamente.");

            var query = _dbContext.TB001_USUARIO.AsNoTracking().AsQueryable();

            request.Senha = BCrypt.Net.BCrypt.HashPassword(request.Senha);

            await _verificarExistenciaUsuario(request, query);

            criou = await _gravarNovoUsuario(request);

            await _gravarLogUsuario(request, query);

            return criou;
        }

        #region Métodos Privados - CriarUsuario
        private async Task _verificarExistenciaUsuario(NovoUsuarioRequest request, IQueryable<TB001_USUARIO> query)
        {
            var usuarioExistente = await query.AnyAsync(x => x.NoUsuario == request.Usuario &&
                                                            x.NoEmail == request.Email);

            if (usuarioExistente)
                new ArgumentException("Email ou Usuários já existentes.");
        }
        private async Task<bool> _gravarNovoUsuario(NovoUsuarioRequest request)
        {
            var novoUsuario = new TB001_USUARIO()
            {
                NoUsuario = request.Usuario,
                NoEmail = request.Email,
                CoSenha = request.Senha
            };

            await _dbContext.AddAsync(novoUsuario);
            var result = await _dbContext.SaveChangesAsync();

            if (result == 0)
                return false;

            return true;
        }
        private async Task _gravarLogUsuario(NovoUsuarioRequest request, IQueryable<TB001_USUARIO> query)
        {
            var usuario = await query.FirstOrDefaultAsync(x => x.NoUsuario == request.Usuario && x.CoSenha == request.Senha);
            var logDTO = new LogUsuarioDTO()
            {
                Usuario = usuario,
                TpOperacao = TipoOperacao.INSERCAO
            };
            await _logService.CriarLogUsuario(logDTO);
        }
        #endregion

        public async Task<UsuarioResponse> BuscarUsuarioId(int Id)
        {
            var usuario = await _consultarUsuario(Id);

            if (usuario == null)
                return null;

            return usuario;
        }

        #region Métodos privados - BuscarUsuarioId
        private async Task<UsuarioResponse> _consultarUsuario(int Id)
        {
            return await _dbContext.TB001_USUARIO
                                          .AsNoTracking()
                                          .Where(x => x.NuUsuario == Id)
                                          .Select(u => new UsuarioResponse()
                                          {
                                              Usuario = u.NoUsuario,
                                              Email = u.NoEmail,
                                              Senha = u.CoSenha
                                          })
                                          .FirstOrDefaultAsync();
        }
        #endregion

        public async Task<bool> EditarUsuario(UsuarioEditadoRequest request, int Id)
        {
            bool alterou = false;
            try
            {
                var usuario = await _dbContext.TB001_USUARIO.FirstOrDefaultAsync(x => x.NuUsuario == Id);
                if (usuario == null)
                {
                    _logger.LogInformation("EditarUsuario: Usuário não encontrado");
                    return alterou;
                }

                alterou = await _alterarInformacoesUsuario(usuario, request);

                await _registrarLogEdicao(Id);

                return alterou;
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

        #region Métodos Privados - EditarUsuario
        private async Task<bool> _alterarInformacoesUsuario(TB001_USUARIO usuario, UsuarioEditadoRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.NovoUsuario))
                usuario.NoUsuario = request.NovoUsuario;

            if (!string.IsNullOrWhiteSpace(request.NovoEmail))
                usuario.NoEmail = request.NovoEmail;

            if (!string.IsNullOrWhiteSpace(request.NovaSenha))
            {
                request.NovaSenha = BCrypt.Net.BCrypt.HashPassword(request.NovaSenha);
                usuario.CoSenha = request.NovaSenha;
            }

            _dbContext.TB001_USUARIO.Update(usuario);
            var resultado = await _dbContext.SaveChangesAsync();

            if (resultado == 0)
                return false;

            return true;
        }
        private async Task _registrarLogEdicao(int Id)
        {
            var usuarioAlterado = await _dbContext.TB001_USUARIO.AsNoTracking().FirstOrDefaultAsync(x => x.NuUsuario == Id);
            var log = new LogUsuarioDTO()
            {
                Usuario = usuarioAlterado,
                TpOperacao = TipoOperacao.EDICAO
            };

            await _logService.CriarLogUsuario(log);
        }
        #endregion

        public async Task<bool> DeletarUsuario(int Id)
        {
            bool deletou = false;
            try
            {
                var usuario = await _dbContext.TB001_USUARIO.FirstOrDefaultAsync(x => x.NuUsuario == Id);

                if (usuario == null)
                    new ArgumentException("Usuário não encontrado.");

                deletou = await _removerUsuarioBanco(usuario);

                deletou = await _registrarDelecaoLog(usuario);

                return deletou;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EditarUsuario: Erro {ex}");
                return false;
            }
        }

        #region Métodos Privados - DeletarUsuario
        private async Task<bool> _removerUsuarioBanco(TB001_USUARIO usuario)
        {
            _dbContext.TB001_USUARIO.Remove(usuario);
            var resultado = await _dbContext.SaveChangesAsync();

            if (resultado == 0)
                return false;

            return true;
        }
        private async Task<bool> _registrarDelecaoLog(TB001_USUARIO usuario)
        {
            var log = new LogUsuarioDTO()
            {
                Usuario = usuario,
                TpOperacao = TipoOperacao.DELECAO
            };
            bool registrou = await _logService.CriarLogUsuario(log);

            return registrou;
        }
        #endregion

    }
}
