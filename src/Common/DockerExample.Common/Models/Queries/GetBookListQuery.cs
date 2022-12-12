using DockerExample.Domain.Dtos.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerExample.Common.Models.Queries
{
  public class GetBookListQuery : IRequest<List<BookDto>>
  {
  }
}
