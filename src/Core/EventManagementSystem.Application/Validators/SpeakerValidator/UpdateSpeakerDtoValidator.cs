using EventManagementSystem.Application.Dtos.EventDto;
using EventManagementSystem.Application.Dtos.SpeakerDto;
using EventManagementSystem.Application.Validators.EventValidator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Validators.SpeakerValidator
{
    public class UpdateSpeakerDtoValidator : BaseSpeakerDtoValidator<UpdateSpeakerDto>
    {
        public UpdateSpeakerDtoValidator()
        {
            RuleFor(speaker => speaker.SpeakerId)
                .NotNull().WithMessage("Id can`t be null")
                .GreaterThanOrEqualTo(0).WithMessage("Id must be a positive number");
        }

    }
}
