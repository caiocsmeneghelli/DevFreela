using DevFreela.Api.Models;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.Api.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMediator _mediator;

        public ProjectsController(IProjectService projectService, IMediator mediator)
        {
            _projectService = projectService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var model = new GetAllProjectsQuery(query);
            var projects = await _mediator.Send(model);
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var inputModel = new GetProjectByIdQuery(id);
            var project = await _mediator.Send(inputModel);
            if (project is null) { return NotFound(); }
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateProjectCommand inputModel)
        {
             if(!ModelState.IsValid)
            {
                var messages = ModelState
                    .SelectMany(reg => reg.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(messages);
            }

            var idProject = await _mediator.Send(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = idProject }, inputModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]UpdateProjectCommand inputModel)
        {
            if (inputModel.Description.Length > 200)
            {
                return BadRequest();
            }
            await _mediator.Send(inputModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var inputModel = new DeleteProjectCommand(id);
            await _mediator.Send(inputModel);
            return NoContent();
        }

        // api/projects/1/comments POST
        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand inputModel)
        {
            // _projectService.CreateComment(inputModel);
            await _mediator.Send(inputModel);
            return NoContent();
        }

        // api/projects/1/start
        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            var inputModel = new StartProjectCommand(id);
            await _mediator.Send(inputModel);
            return NoContent();
        }

        // api/projects/1/finish
        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish(int id)
        {
            var inputModel = new FinishProjectCommand(id);
            await _mediator.Send(inputModel);
            return NoContent();
        }
    }
}