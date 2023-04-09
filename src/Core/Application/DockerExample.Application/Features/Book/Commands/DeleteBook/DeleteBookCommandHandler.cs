using DockerExample.Application.Services.UnitOfWork;
using DockerExample.Common.Models.Commands.Book;
using DockerExample.Common.Results;
using MediatR;

namespace DockerExample.Application.Features.Book.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork._bookRepository.DeleteAsync(request.Id);

            return new Result(true, "Successful");
        }
    }
}
