using EventManagementSystem.Application.Dtos.EventDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Validators.EventValidator
{
    public class BaseEventDtoValidator : AbstractValidator<BaseEventDto>
    {
        public BaseEventDtoValidator()
        {
            RuleFor(ev => ev.Title)
                .NotEmpty().WithMessage("Title can`t be empty")
                .Length(4, 40).WithMessage("Title lenght must be between 4 and 40 characters");

            RuleFor(ev => ev.Description)
                .NotEmpty().WithMessage("Description can`t be empty")
                .MinimumLength(10).WithMessage("Description must contain more than 10 characters")
                .MaximumLength(500).WithMessage("Description must be shorter than 500 characters");

            RuleFor(ev => ev.Date).NotNull().WithMessage("Event date can`t be null")
                .GreaterThan(DateOnly.FromDateTime(DateTime.Today)).WithMessage("Enter a valid event date");

            RuleFor(ev => ev.Location)
                .NotEmpty().WithMessage("Location can`t be null")
                .Length(10,50).WithMessage("Location must be be speacified between 10 and 50 characters");
        }
    }
}
