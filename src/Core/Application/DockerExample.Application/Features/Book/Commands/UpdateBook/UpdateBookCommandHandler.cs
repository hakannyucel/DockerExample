using AutoMapper;
using DockerExample.Application.Services.Repositories;
using DockerExample.Common.Models.Commands.Book;
using MediatR;

namespace DockerExample.Application.Features.Book.Commands.UpdateBook
{
  public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Guid>
  {
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;

    public UpdateBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
    {
      _mapper = mapper;
      _bookRepository = bookRepository;
    }

    public async Task<Guid> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
      Domain.Entities.Book dbBook = await _bookRepository.GetAsync(request.Id);
      Domain.Entities.Book requestBook = _mapper.Map<Domain.Entities.Book>(request);

      _mapper.Map(dbBook, requestBook);

      return request.Id;
    }
  }
}
