using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DockerExample.Domain.Common
{
  public interface IEntityRepository<T> where T : BaseEntity
  {
        Task AddAsync(T entity);
        public Task<T> GetAsync(Guid id);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null, 
          Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, 
          Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, 
          bool noTracking = true, 
          CancellationToken cancellationToken = default);

        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
