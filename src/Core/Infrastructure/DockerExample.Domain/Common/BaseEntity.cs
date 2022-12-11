namespace DockerExample.Domain.Common
{
  public class BaseEntity
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreateDate { get; set; } = DateTime.Now;
  }
}
