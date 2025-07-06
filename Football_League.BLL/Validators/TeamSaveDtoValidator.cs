using FluentValidation;
using Football_League.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Football_League.BLL.DTOs.TeamDtos;


namespace Football_League.BLL.Validators
{
    public class TeamSaveDtoValidator : AbstractValidator<TeamSaveDto>
    {
        public TeamSaveDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Team name cannot be empty.");

            RuleFor(x => x.Code)
                .InclusiveBetween(1, 99).WithMessage("Team code must be between 1 and 99.");

            RuleFor(x => x.StadiumId)
                .GreaterThan(0).WithMessage("Stadium ID must be valid.");
        }
    }

}
