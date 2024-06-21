using Application.DTO.Request;
using Application.DTO.Response;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsuarioService
    {
        private readonly ILogger<UsuarioService> _logger;
        private readonly DbContextBase _dbContext;
        public UsuarioService(
               DbContextBase dbContext,
               ILogger<UsuarioService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> CriarUsuario(NovoUsuarioRequest request)
        {
            if (request == null)
                new ArgumentException("Dados da requisição vazios, preencha novamente.");

            var usuarioExistente = await _dbContext.UsuarioModel
                                          .AsNoTracking()
                                          .Where(x => x.Usuario == request.Usuario || x.Email == request.Email)
                                          .AnyAsync();

            if (usuarioExistente)
                new ArgumentException("Email ou Usuários já existentes.");

            var novoUsuario = new UsuarioModel()
            {
                Usuario = request.Usuario,
                Email = request.Email,
                Senha = request.Senha
            };

            await _dbContext.AddAsync(novoUsuario);
            var result = await _dbContext.SaveChangesAsync();

            if (result == 0)
                return false;

            return true;
        }
        public async Task<UsuarioResponse> ListarInformacoesUsuario(int Id)
        {
            var usuario = await _dbContext.UsuarioModel
                                          .AsNoTracking()
                                          .Where(x => x.Id == Id)
                                          .FirstOrDefaultAsync();
            if (usuario == null)
                return new UsuarioResponse();

            var response = new UsuarioResponse()
            {
                Email = usuario.Email,
                Usuario = usuario.Usuario,
                Senha = usuario.Senha
            };
            return response;
        }
        public async Task<bool> EditarUsuario(UsuarioEditadoRequest request, int Id)
        {
            try
            {
                var usuario = await _dbContext.UsuarioModel
                                                      .Where(x => x.Id == Id)
                                                      .FirstOrDefaultAsync();

                if (usuario == null)
                {
                    _logger.LogInformation("EditarUsuario: Usuário não encontrado");
                    return false;
                }

                usuario.Usuario = request.NovoUsuario;
                usuario.Email = request.NovoEmail;
                usuario.Senha = request.NovaSenha;

                _dbContext.UsuarioModel.Update(usuario);
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
