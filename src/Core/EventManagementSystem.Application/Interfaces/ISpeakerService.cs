using EventManagementSystem.Application.Dtos.SpeakerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Interfaces
{
    public interface ISpeakerService
    {
        void Add(CreateSpeakerDto entity);
        ReadSpeakerDto Get(int id);
        List<ReadSpeakerDto> GetAll();
        void Update(UpdateSpeakerDto entity);
        void Delete(int id);
    }
}
