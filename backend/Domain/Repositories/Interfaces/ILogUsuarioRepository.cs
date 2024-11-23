using Domain.Entities;

namespace Domain.Repositories.Interfaces
{
    public interface ILogUsuarioRepository : IRepository<TB501_LOG_USUARIO>
    {
        Task GerarLog(TB001_USUARIO usuario, short TipoOperacao);
    }
}
