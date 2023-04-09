using DockerExample.Common.Models.Commands.Book;
using DockerExample.Common.Models.Queries.Book;
using DockerExample.Common.Results;
using DockerExample.Domain.Entities;
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

        [HttpGet("GetList")]
        [ProducesResponseType(typeof(IResult<List<Book>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBookListAsync()
        {
            return Ok(await _mediator.Send(new GetBookListQuery()));
        }

        [HttpPost("Add")]
        [ProducesResponseType(typeof(IResult<Guid>), StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddBookAsync([FromBody] CreateBookCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("Update")]
        [ProducesResponseType(typeof(IResult<Guid>), StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateBookAsync([FromBody] UpdateBookCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("Delete/{id:Guid}")]
        [ProducesResponseType(typeof(Common.Results.IResult), StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteBookAsync([FromRoute] Guid id)
        {
            var command = new DeleteBookCommand { Id = id };
            return Ok(await _mediator.Send(command));
        }
    }
}
