using MediatR;

namespace DockerExample.Common.Models.Commands.Book
{
  public class CreateBookCommand : IRequest<Guid>
  {
    public string Name { get; set; }
  }
}
