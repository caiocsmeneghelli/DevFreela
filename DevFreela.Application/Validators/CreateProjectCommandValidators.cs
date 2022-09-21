using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.Commands.CreateProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateProjectCommandValidators : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidators()
        {
            RuleFor(reg => reg.Description)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo de Descrição é de 255 caracteres.");
            RuleFor(reg => reg.Title)
                .MaximumLength(30)
                .WithMessage("Tamanho máximo de Titulo é de 30 caracteres.");
        }
    }
}