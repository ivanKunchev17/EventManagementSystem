using EventManagementSystem.Application.Dtos.UserDto;
using EventManagementSystem.Application.Validators.EventValidator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Validators.UserValidator
{
    public class UpdateUserDtoValidator : BaseUserDtoValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator() 
        { 
            RuleFor(user=>user.UserId)
                .NotNull().WithMessage("Id can`t be null")
                .GreaterThanOrEqualTo(0).WithMessage("Id must be a positive number");
        }
    }
}
