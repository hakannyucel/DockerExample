using DockerExample.Common.Results;
using MediatR;

namespace DockerExample.Common.Models.Commands.Book
{
    public class DeleteBookCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
    }
}
