using MediatR;

namespace DockerExample.Common.Models.Commands.Book
{
  public class UpdateBookCommand : IRequest<Guid>
  {
    public Guid Id { get; set; }
  }
}
