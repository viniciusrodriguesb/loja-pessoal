namespace Domain.Repositories.Interfaces
{
    public interface IRepository<TEntity> : IDisposable
    {
        Task Adicionar(TEntity entity);
        Task AdicionarRange(List<TEntity> entities);
        Task Atualizar(TEntity entity);
        Task AtualizarRange(List<TEntity> entities);
        Task Remover(TEntity entity);
    }
}
