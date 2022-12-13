using MediatR;

namespace DockerExample.Common.Models.Commands.Book
{
  public class CreateBookCommand : IRequest<int>
  {
    public string Name { get; set; }
  }
}
