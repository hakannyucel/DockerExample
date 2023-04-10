using AutoMapper;
using DockerExample.Application.Services.Repositories;
using DockerExample.Common.Models.Commands.Book;
using DockerExample.Common.Results;
using MediatR;

namespace DockerExample.Application.Features.Book.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, IResult<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<IResult<Guid>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Book dbBook = await _bookRepository.GetAsync(request.Id);
            Domain.Entities.Book requestBook = _mapper.Map<Domain.Entities.Book>(request);

            dbBook.Name = requestBook.Name;
            dbBook.Page = requestBook.Page;

            return new Result<Guid>(true, "Successful", request.Id);
        }
    }
}
