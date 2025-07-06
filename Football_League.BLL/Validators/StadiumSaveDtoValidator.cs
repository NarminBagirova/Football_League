using FluentValidation;
using Football_League.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Football_League.BLL.DTOs.StadiumDtos;

namespace Football_League.BLL.Validators
{
    public class StadiumSaveDtoValidator : AbstractValidator<StadiumSaveDto>
    {
        public StadiumSaveDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Stadium name cannot be empty.")
                .Length(1, 100).WithMessage("Stadium name must be between 1 and 100 characters.");

            RuleFor(x => x.Capacity)
                .GreaterThan(0).WithMessage("Stadium capacity must be greater than zero.");
        }
    }
}
