using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.Commands.CreateUser;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(reg => reg.Email)
                .EmailAddress()
                .WithMessage("E-mail invalido.");
            RuleFor(reg => reg.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome obrigatório.");
        }
    }
}