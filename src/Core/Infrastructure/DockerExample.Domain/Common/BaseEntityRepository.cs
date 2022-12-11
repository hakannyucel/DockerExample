using Microsoft.EntityFrameworkCore;

namespace DockerExample.Domain.Common
{
  public class BaseEntityRepository<T, TContext> : IEntityRepository<T>
    where T : BaseEntity, new()
    where TContext : DbContext, new()
  {
    protected TContext _context;
    protected DbSet<T> _entity => _context.Set<T>();

    public BaseEntityRepository(TContext context)
    {
      _context = context;
    }

    public async Task<T> GetAsync(Guid id)
    {
      return await _entity.FirstOrDefaultAsync(x => x.Id == id);
    }
  }
}
