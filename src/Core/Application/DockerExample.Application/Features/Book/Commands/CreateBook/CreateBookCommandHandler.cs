﻿using AutoMapper;
using DockerExample.Application.Services.UnitOfWork;
using DockerExample.Common.Models.Commands.Book;
using DockerExample.Common.Results;
using MediatR;

namespace DockerExample.Application.Features.Book.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, IResult<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult<Guid>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            Domain.Entities.Book book = _mapper.Map<Domain.Entities.Book>(request);
            book.Id = id;
            book.CreateDate = DateTime.Now;

            await _unitOfWork._bookRepository.AddAsync(book);
            await _unitOfWork.CommitAsync();

            return new Result<Guid>(true, "Successful", id);
        }
    }
}
