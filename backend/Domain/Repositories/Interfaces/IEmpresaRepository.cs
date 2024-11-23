using Domain.Entities;

namespace Domain.Repositories.Interfaces
{
    public interface IEmpresaRepository : IRepository<TB002_EMPRESA>
    {
        Task<TB002_EMPRESA?> BuscarEmpresaCnpj(string CNPJ);
        Task<TB002_EMPRESA?> BuscarEmpresaId(int NuEmpresa);
    }
}
