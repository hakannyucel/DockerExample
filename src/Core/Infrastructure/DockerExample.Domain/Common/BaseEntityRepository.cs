using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Linq;

namespace DockerExample.Domain.Common
{
  public class BaseEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : BaseEntity, new()
    where TContext : DbContext, new()
  {
    protected TContext _context;
    protected DbSet<TEntity> _entity => _context.Set<TEntity>();

    public BaseEntityRepository(TContext context)
    {
      _context = context;
    }

    public async Task<TEntity> GetAsync(Guid id)
    {
      return await _entity.FirstOrDefaultAsync(x => x.Id == id);
    }

    public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy =
                                                           null,
                                                       Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>?
                                                           include = null,
                                                       bool noTracking = true,
                                                       CancellationToken cancellationToken = default)
    {
      IQueryable<TEntity> query = _entity;
      if (!noTracking) query = query.AsNoTracking();
      if (include != null) query = include(query);
      if (predicate != null) query = query.Where(predicate);
      if (orderBy != null)
        return await orderBy(query).ToListAsync(cancellationToken);
      return await query.ToListAsync(cancellationToken);
    }
  }
}
