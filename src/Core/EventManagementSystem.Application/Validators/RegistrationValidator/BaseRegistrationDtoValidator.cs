using EventManagementSystem.Application.Dtos.RegistrationDto;
using EventManagementSystem.Application.Dtos.SpeakerDto;
using EventManagementSystem.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Validators.RegistrationValidator
{
    public class BaseRegistrationDtoValidator<T> : AbstractValidator<T> where T : BaseRegistrationDto
    {
        public BaseRegistrationDtoValidator()
        {
            RuleFor(registration => registration.EventId)
                .NotNull().WithMessage("Registration must contain an eventId")
                .GreaterThanOrEqualTo(0).WithMessage("EventId must be a positive number");

            RuleFor(registration => registration.UserEmail)
                .NotEmpty().WithMessage("User email is required")
                .EmailAddress().WithMessage("Invalid user email")
                .Length(5, 50).WithMessage("Email must be between 5 and 50 characters");

        }
    }
}
