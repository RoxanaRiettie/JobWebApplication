using JobWebApplication.Application.DTOs;
using JobWebApplication.Application.Handlers;
using JobWebApplication.Infrastructure.Commands;
using JobWebApplication.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPositionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobPositionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<JobPositionDto>> GetJobs()
        {
            return await _mediator.Send(new GetAllJobPositionsQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobPositionDto>> GetJobById(int id)
        {
            var query = new GetJobPositionByIdQuery(id);
            var job = await _mediator.Send(query);
            if (job == null) return NotFound();
            return Ok(job);

        }

        [HttpPost]
        public async Task<ActionResult<JobPositionDto>> CreateJob(CreateJobPositionCommand command)
        {
            var job = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetJobById), new { id = job.Id }, job);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, UpdateJobPositionCommand command) {
            if (id != command.Id) return BadRequest();
            var jobPosition = await _mediator.Send(command);
            if (jobPosition == null) {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id) { 
           var job = await _mediator.Send(new DeleteJobPositionCommand(id));
           return !job ? NotFound() : NoContent();

        }
    }
}
