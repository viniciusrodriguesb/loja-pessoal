using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class UsuarioRepository : Repository<TB001_USUARIO>, IUsuarioRepository
    {

        public UsuarioRepository(DbContextBase dbContext) : base(dbContext) { }

        public async Task<TB001_USUARIO?> BuscarUsuario(string usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario))
                throw new ArgumentException("O nome do usuário não pode ser nulo ou vazio.", nameof(usuario));

            return await _dbContext.TB001_USUARIO
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(x => x.NoUsuario == usuario);
        }
        public async Task<TB001_USUARIO?> BuscarUsuarioId(int id)
        {            
            return await _dbContext.TB001_USUARIO
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(x => x.NuUsuario == id);
        }
        public async Task CriarUsuario(string Usuario, string Email, string Senha)
        {
            if (string.IsNullOrWhiteSpace(Usuario) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Senha))
                throw new ArgumentException("Usuário, email e senha são obrigatórios.");

            await VerificarExistenciaUsuario(Usuario, Senha);

            var novoUsuario = new TB001_USUARIO()
            {
                NoUsuario = Usuario,
                NoEmail = Email,
                CoSenha = Senha
            };

            await Adicionar(novoUsuario);

        }
        public async Task AlterarUsuario(TB001_USUARIO usuario, string? NovoUsuario, string? NovaSenha, string? NovoEmail)
        {
            if (!string.IsNullOrWhiteSpace(NovoUsuario))
                usuario.NoUsuario = NovoUsuario;

            if (!string.IsNullOrWhiteSpace(NovoEmail))
                usuario.NoEmail = NovoEmail;

            if (!string.IsNullOrWhiteSpace(NovaSenha))
            {
                NovaSenha = BCrypt.Net.BCrypt.HashPassword(NovaSenha);
                usuario.CoSenha = NovaSenha;
            }

            await Atualizar(usuario);
        }
        public async Task VerificarExistenciaUsuario(string Usuario, string Email)
        {
            var usuarioExistente = await _dbContext.TB001_USUARIO
                                                   .AsNoTracking()
                                                   .AnyAsync(x => x.NoUsuario == Usuario &&
                                                                  x.NoEmail == Email);

            if (usuarioExistente)
                throw new ArgumentException("Email ou Usuários já existentes.");
        }

    }
}
