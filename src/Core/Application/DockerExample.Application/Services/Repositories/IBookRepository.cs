using DockerExample.Domain.Common;
using DockerExample.Domain.Entities;

namespace DockerExample.Application.Services.Repositories
{
  public interface IBookRepository : IEntityRepository<Book>
  {
  }
}
