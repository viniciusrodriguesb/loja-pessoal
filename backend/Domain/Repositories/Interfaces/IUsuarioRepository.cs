using Domain.Entities;

namespace Domain.Repositories.Interfaces
{
    public interface IUsuarioRepository : IRepository<TB001_USUARIO>
    {
        Task<TB001_USUARIO?> BuscarUsuario(string Usuario);
        Task<TB001_USUARIO?> BuscarUsuarioId(int Id);
        Task VerificarExistenciaUsuario(string Usuario, string Email);
        Task CriarUsuario(string Usuario, string Email, string Senha);
        Task AlterarUsuario(TB001_USUARIO usuario, string? NovoUsuario, string? NovaSenha, string? NovoEmail);
    }
}
