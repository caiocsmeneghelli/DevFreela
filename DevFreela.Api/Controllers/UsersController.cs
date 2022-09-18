using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Api.Models;
using DevFreela.Application.Queries.GetUserById;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMediator _mediator;

        public UsersController(IUserService userService, IMediator mediator)
        {
            _userService = userService;
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var inputModel = new GetUserByIdQuery(id);
            var user = await _mediator.Send(inputModel);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserViewModel inputModel)
        {
            var idUser = _userService.Create(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = idUser }, inputModel);
        }
        // api/users/1/login
        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel loginModel)
        {
            // Sera feito no modulo de autenticacao
            return NoContent();
        }
    }
}