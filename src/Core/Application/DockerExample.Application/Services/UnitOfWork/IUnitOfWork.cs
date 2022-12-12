using DockerExample.Application.Services.Repositories;

namespace DockerExample.Application.Services.UnitOfWork
{
  public interface IUnitOfWork : IDisposable
  {
    IBookRepository _bookRepository { get; }

    Task<int> CommitAsync();
    int Commit();
    void Dispose();
  }
}
