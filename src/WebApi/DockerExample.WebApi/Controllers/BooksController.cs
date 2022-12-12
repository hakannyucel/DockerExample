using DockerExample.Common.Models.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
  }
}
