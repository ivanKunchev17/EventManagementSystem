using EventManagementSystem.Application.Dtos.RegistrationDto;
using EventManagementSystem.Application.Validators.EventValidator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Validators.RegistrationValidator
{
    public class UpdateRegistrationDtoValidator : BaseRegistrationDtoValidator<UpdateRegistrationDto>
    {
        public UpdateRegistrationDtoValidator() 
        {
            RuleFor(registration => registration.RegistrationId)
                .NotNull().WithMessage("Id can`t be null")
                .GreaterThanOrEqualTo(0).WithMessage("Id must be a positive number");
        }
    }
}
