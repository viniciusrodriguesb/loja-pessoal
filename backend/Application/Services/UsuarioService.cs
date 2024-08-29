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
        private readonly ILogger<UsuarioService> _logger;
        private readonly DbContextBase _dbContext;
        public UsuarioService(
               DbContextBase dbContext,
               ILogger<UsuarioService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        public async Task<bool> CriarUsuario(NovoUsuarioRequest request)
        {
            if (request == null)
                new ArgumentException("Dados da requisição vazios, preencha novamente.");

            var usuarioExistente = await _dbContext.TB001_USUARIO
                                          .AsNoTracking()
                                          .Where(x => x.NoUsuario == request.Usuario || x.NoEmail == request.Email)
                                          .AnyAsync();

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

            if (result == 0)
                return false;

            return true;
        }
        public async Task<UsuarioResponse> ListarInformacoesUsuario(int Id)
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
    }
}
