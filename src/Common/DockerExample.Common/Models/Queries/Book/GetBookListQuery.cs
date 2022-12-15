using DockerExample.Domain.Dtos.Book;
using MediatR;

namespace DockerExample.Common.Models.Queries.Book
{
  public class GetBookListQuery : IRequest<List<BookDto>>
    {
    }
}
