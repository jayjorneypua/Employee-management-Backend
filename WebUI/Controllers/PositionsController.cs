using Application.DTOs;
using Application.Features.Positions.Commands;
using Application.Features.Positions.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IMediator mediator;

        public PositionsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PositionDto>>> GetPositions()
        {
            try
            {
                var positions = await mediator.Send(new GetPositionsQuery());
                return Ok(positions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreatePosition(CreatePositionCommand command)
        {
            try
            {
                var positionId = await mediator.Send(command);
                return Ok(positionId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePosition(int id, UpdatePositionCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            try
            {
                await mediator.Send(command);
                return Ok();    
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosition(int id)
        {
            try
            {
                await mediator.Send(new DeletePositionCommand { Id = id });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
