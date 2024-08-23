using AutoMapper;
using EventManagementSystem.Application.Dtos.SpeakerDto;
using EventManagementSystem.Application.Interfaces;
using EventManagementSystem.Application.IRepository;
using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Services
{
    public class SpeakerService : ISpeakerService
    {
        private readonly IRepository<Speaker> _repository;
        private readonly IMapper _mapper;
        public SpeakerService(IRepository<Speaker> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(CreateSpeakerDto entity)
        {
            Speaker speakerFromClient = _mapper.Map<Speaker>(entity);
            _repository.Create(speakerFromClient);
        }

        public ReadSpeakerDto Get(int id)
        {
            Speaker speakerFromDb = _repository.Read(id, false);
            return _mapper.Map<ReadSpeakerDto>(speakerFromDb);
        }

        public List<ReadSpeakerDto> GetAll()
        {
            List<Speaker> speakersFromDb = _repository.ReadAll(false);
            return _mapper.Map<List<ReadSpeakerDto>>(speakersFromDb);
        }

        public void Update(UpdateSpeakerDto entity)
        {
            Speaker speakerFromClient = _mapper.Map<Speaker>(entity);
            _repository.Update(speakerFromClient);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
