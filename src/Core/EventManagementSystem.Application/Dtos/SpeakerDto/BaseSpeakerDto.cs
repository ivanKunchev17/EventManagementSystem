﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Dtos.SpeakerDto
{
    public abstract class BaseSpeakerDto
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public string Email { get; set; }
    }
}
