using EventManagementSystem.Application.Dtos.EventDto;
using EventManagementSystem.Application.Dtos.SpeakerDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Validators.SpeakerValidator
{
    public class BaseSpeakerDtoValidator<T> : AbstractValidator<T> where T : BaseSpeakerDto
    {
        public BaseSpeakerDtoValidator()
        {
            RuleFor(speaker=>speaker.Name)
                .NotEmpty().WithMessage("Name can`t be null")
                .Length(3, 60);

            RuleFor(speaker => speaker.Description)
                .NotEmpty().WithMessage("Description can`t be null")
                .Length(10,500).WithMessage("Description must have between 10 and 500 characters");

            RuleFor(speaker => speaker.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email"); 

        }
    }
}
