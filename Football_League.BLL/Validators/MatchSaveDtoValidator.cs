using FluentValidation;
using Football_League.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.BLL.Validators
{
    public class MatchSaveDtoValidator : AbstractValidator<MatchDtos.MatchSaveDto>
    {
        public MatchSaveDtoValidator()
        {
            RuleFor(x => x.HomeTeamId)
                .GreaterThan(0).WithMessage("Home team ID must be valid.");

            RuleFor(x => x.AwayTeamId)
                .GreaterThan(0).WithMessage("Away team ID must be valid.");

            RuleFor(x => x.WeekNumber)
                .GreaterThan(0).WithMessage("Week number must be greater than zero.");

            RuleFor(x => x.HomeGoals)
                .GreaterThanOrEqualTo(0).WithMessage("Home team goals must be greater than or equal to zero.");

            RuleFor(x => x.AwayGoals)
                .GreaterThanOrEqualTo(0).WithMessage("Away team goals must be greater than or equal to zero.");
        }
    }

}
