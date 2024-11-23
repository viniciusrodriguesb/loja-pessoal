using Domain.Entities;

namespace Domain.Repositories.Interfaces
{
    public interface ILogEmpresaRepository : IRepository<TB502_LOG_EMPRESA>
    {
        Task GerarLog(TB002_EMPRESA empresa, short TipoOperacao);
    }
}
