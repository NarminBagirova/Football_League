using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Football_League.BLL.DTOs.PlayerDtos;

namespace Football_League.BLL.Validators
{
    public class PlayerSaveDTOValidator : AbstractValidator<PlayerSaveDto>
    {
        public class PlayerSaveDtoValidator : AbstractValidator<PlayerSaveDto>
        {
            public PlayerSaveDtoValidator()
            {
                RuleFor(x => x.FirstName)
                    .NotEmpty().WithMessage("First name cannot be empty.");

                RuleFor(x => x.LastName)
                    .NotEmpty().WithMessage("Last name cannot be empty.");

                RuleFor(x => x.TeamId)
                    .GreaterThan(0).WithMessage("TeamId must be greater than 0.");

                RuleFor(x => x.ShirtNumber)
                    .GreaterThan(0).WithMessage("Shirt number must be greater than 0.");
            }
        }
    }
}
