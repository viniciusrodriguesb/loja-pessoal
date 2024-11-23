using Domain.Repositories.Interfaces;

namespace Domain.Repositories
{
    public class Repository<T> : IRepository<T> 
    {
        #region Constructor
        protected readonly DbContextBase _dbContext;
        public Repository(DbContextBase dbContext)
        {
            _dbContext = dbContext;
        } 
        #endregion

        public virtual async Task Adicionar(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task AdicionarRange(List<T> entities)
        {
            await _dbContext.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task Atualizar(T entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task AtualizarRange(List<T> entities)
        {
            _dbContext.UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task Remover(T entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            _dbContext.Dispose();
        }

    }
}
