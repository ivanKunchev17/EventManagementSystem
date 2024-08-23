using EventManagementSystem.Application.Dtos.EventDto;
using EventManagementSystem.Application.Dtos.UserDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Validators.UserValidator
{
    public class BaseUserDtoValidator<T> : AbstractValidator<T> where T : BaseUserDto
    {
        public BaseUserDtoValidator()
        {
            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage("First name can`t be null")
                .Length(1, 25);

            RuleFor(user => user.LastName)
                .NotEmpty().WithMessage("Last name can`t be null")
                .Length(1, 40);

            RuleFor(user => user.Email)
                 .NotEmpty().WithMessage("Email is required")
                 .EmailAddress().WithMessage("Invalid email")
                 .Length(5,50).WithMessage("Email must be between 5 and 50 characters");

            RuleFor(user => user.DateOfBirth)
                .NotNull().WithMessage("Date of birth can`t be null")
                .LessThan(DateOnly.FromDateTime(DateTime.Today)).WithMessage("Enter a valid date of birth");
        }
    }
}
