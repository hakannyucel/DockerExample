using AutoMapper;
using DockerExample.Application.Services.UnitOfWork;
using DockerExample.Common.Models.Queries.Book;
using DockerExample.Common.Results;
using DockerExample.Domain.Dtos.Book;
using MediatR;

namespace DockerExample.Application.Features.Book.GetBookList
{
    public class GetBookListQueryHandler : IRequestHandler<GetBookListQuery, IResult<List<BookDto>>>
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetBookListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IResult<List<BookDto>>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
    {
      List<Domain.Entities.Book> books = await _unitOfWork._bookRepository.GetListAsync();

      List<BookDto> mappedBooks = _mapper.Map<List<BookDto>>(books);

      return new Result<List<BookDto>>(true, "Successful", mappedBooks);
    }
  }
}
