using EventManagementSystem.Application.Dtos.EventDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Validators.EventValidator
{
    public class UpdateEventDtoValidator : AbstractValidator<UpdateEventDto>
    {
        public UpdateEventDtoValidator()
        {
            Include(new BaseEventDtoValidator());

            RuleFor(user => user.EventId)
                .NotNull().WithMessage("Id can`t be null")
                .GreaterThanOrEqualTo(0).WithMessage("Id must be a positive number");

        }
    }
}
