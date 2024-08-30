using Application.Constantes.Enums;
using Application.DTO.LogDTO;
using Application.DTO.Request;
using Application.DTO.Response;
using Domain.Entities;
using Infrastructure.Persistence;
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
        public UsuarioService(
               LogService logService,
               DbContextBase dbContext,
               ILogger<UsuarioService> logger)
        {
            _logService = logService;
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        public async Task<bool> CriarUsuario(NovoUsuarioRequest request)
        {
            if (request == null)
                new ArgumentException("Dados da requisição vazios, preencha novamente.");

            var query = _dbContext.TB001_USUARIO.AsNoTracking().AsQueryable();

            var usuarioExistente = await query.AnyAsync(x => x.NoUsuario == request.Usuario &&
                                                             x.NoEmail == request.Email);

            if (usuarioExistente)
                new ArgumentException("Email ou Usuários já existentes.");

            var novoUsuario = new TB001_USUARIO()
            {
                NoUsuario = request.Usuario,
                NoEmail = request.Email,
                CoSenha = request.Senha
            };

            await _dbContext.AddAsync(novoUsuario);
            var result = await _dbContext.SaveChangesAsync();

            var usuario = await query.FirstOrDefaultAsync(x => x.NoUsuario == request.Usuario && x.CoSenha == request.Senha);
            var logDTO = new LogUsuarioDTO()
            {
                Usuario = usuario,
                TpOperacao = TipoOperacao.INSERCAO
            };

            await _logService.CriarLogUsuario(logDTO);

            if (result == 0)
                return false;

            return true;
        }
        public async Task<UsuarioResponse> BuscarUsuarioId(int Id)
        {
            var usuario = await _dbContext.TB001_USUARIO
                                          .AsNoTracking()
                                          .Where(x => x.NuUsuario == Id)
                                          .Select(u => new UsuarioResponse()
                                          {
                                              Usuario = u.NoUsuario,
                                              Email = u.NoEmail,
                                              Senha = u.CoSenha
                                          })
                                          .FirstOrDefaultAsync();

            if (usuario == null)
                return null;

            return usuario;
        }
        public async Task<bool> EditarUsuario(UsuarioEditadoRequest request, int Id)
        {
            try
            {
                var usuario = await _dbContext.TB001_USUARIO.FirstOrDefaultAsync(x => x.NuUsuario == Id);
                if (usuario == null)
                {
                    _logger.LogInformation("EditarUsuario: Usuário não encontrado");
                    return false;
                }

                usuario.NoUsuario = request.NovoUsuario;
                usuario.NoEmail = request.NovoEmail;
                usuario.CoSenha = request.NovaSenha;

                _dbContext.TB001_USUARIO.Update(usuario);
                await _dbContext.SaveChangesAsync();

                var usuarioAlterado = await _dbContext.TB001_USUARIO.AsNoTracking().FirstOrDefaultAsync(x => x.NuUsuario == Id);
                var log = new LogUsuarioDTO()
                {
                    Usuario = usuarioAlterado,
                    TpOperacao = TipoOperacao.EDICAO
                };

                await _logService.CriarLogUsuario(log);

                return true;
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
        public async Task<bool> DeletarUsuario(int Id)
        {
            try
            {
                var usuario = await _dbContext.TB001_USUARIO.FirstOrDefaultAsync(x => x.NuUsuario == Id);

                if (usuario == null)
                    new ArgumentException("Usuário não encontrado.");

                _dbContext.TB001_USUARIO.Remove(usuario);
                var resultado = await _dbContext.SaveChangesAsync();

                if (resultado == 0)
                    return false;

                var log = new LogUsuarioDTO()
                {
                    Usuario = usuario,
                    TpOperacao = TipoOperacao.DELECAO
                };
                await _logService.CriarLogUsuario(log);

                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"EditarUsuario: Erro {ex}");
                return false;
            }
        }
    }
}
