﻿using DockerExample.Common.Results;
using MediatR;

namespace DockerExample.Common.Models.Commands.Book
{
    public class UpdateBookCommand : IRequest<IResult<Guid>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Page { get; set; }
    }
}
