using DockerExample.Application.Services.Repositories;
using DockerExample.Persistence.Contexts;

namespace DockerExample.Persistence.UnitOfWork
{
  public class UnitOfWork
    {
    private readonly LibraryContext _context;
    public UnitOfWork(LibraryContext context, IBookRepository bookRepository)
    {
      _context = context;
      _bookRepository = bookRepository;
    }
    public IBookRepository _bookRepository { get; private set; }

    public Task<int> CommitAsync()
    {
      return _context.SaveChangesAsync();

    }
    public int Commit()
    {
      return _context.SaveChanges();

    }
    public void Dispose()
    {
      _context.Dispose();
    }
  }
}
