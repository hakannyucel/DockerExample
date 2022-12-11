namespace DockerExample.Domain.Common
{
  public interface IEntityRepository<T>
    where T : BaseEntity, new()
  {
    public Task<T> GetAsync(Guid id);
  }
}
