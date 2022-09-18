using DevFreela.Api.Models;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
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
        public async  Task<IActionResult> Get(string query)
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
            if (inputModel.Title.Length > 50)
            {
                return BadRequest();
            }

            var idProject = await _mediator.Send(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = idProject }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UpdateProjectInputModel inputModel)
        {
            if (inputModel.Description.Length > 200)
            {
                return BadRequest();
            }
            _projectService.Update(inputModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);
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
        public IActionResult Start(int id)
        {
            _projectService.Start(id);
            return NoContent();
        }

        // api/projects/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);
            return NoContent();
        }
    }
}