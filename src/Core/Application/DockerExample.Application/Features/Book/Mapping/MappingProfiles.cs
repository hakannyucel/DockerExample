using AutoMapper;
using DockerExample.Domain.Dtos.Book;

namespace DockerExample.Application.Features.Book.Mapping
{
  public class MappingProfiles : Profile
  {
    public MappingProfiles()
    {
      CreateMap<Domain.Entities.Book, BookDto>().ReverseMap();
    }
  }
}
