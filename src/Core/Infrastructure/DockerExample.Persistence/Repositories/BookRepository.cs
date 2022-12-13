using DockerExample.Application.Services.Repositories;
using DockerExample.Domain.Common;
using DockerExample.Domain.Entities;
using DockerExample.Persistence.Contexts;

namespace DockerExample.Persistence.Repositories
{
    public class BookRepository : BaseEntityRepository<Book, LibraryContext>, IBookRepository
    {
        public BookRepository(LibraryContext context) : base(context)
        {
        }
    }
}
