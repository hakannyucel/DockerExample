using DockerExample.Common.Results;
using MediatR;

namespace DockerExample.Common.Models.Commands.Book
{
    public class CreateBookCommand : IRequest<IResult<Guid>>
    {
        public string Name { get; set; }
        public int Page { get; set; }
    }
}
