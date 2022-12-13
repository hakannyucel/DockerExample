using DockerExample.Common.Models.Commands.Book;
using DockerExample.Common.Models.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace DockerExample.WebApi.Controllers
{
  [Route("api/v1/[controller]")]
  [ApiController]
  public class BooksController : ControllerBase
  {
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetBookListAsync()
    {
      return Ok(await _mediator.Send(new GetBookListQuery()));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> AddBookAsync([FromBody] CreateBookCommand command)
    {
      var result = await _mediator.Send(command);

      return Ok(new { id = result });
    }
  }
}
