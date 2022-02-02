using AutoMapper;
using DixRacing.Core.Dtos;
using DixRacing.Core.Models.Response;
using DixRacing.Data;
using DixRacing.Data.Entites;
using DixRacing.Data.Interfaces;
using DixRacing.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Services
{
    public class EventService : IEventService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEventParticipantsRepository _eventParticipantsRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public EventService(IUserRepository userRepository,
                            IEventParticipantsRepository eventParticipantsRepository,
                            IMapper mapper, DataContext dataContext)
        {
            _userRepository = userRepository;
            _eventParticipantsRepository = eventParticipantsRepository;
            _mapper = mapper;
            _dataContext = dataContext;
        }
        public async Task<ICollection<GetEventParticipantsResponse>> GetEventParticipantsResponsesByEventId(int eventId)
        {
            var eventParticipants= await _dataContext.EventParticipants.Where(x=>x.EventId==eventId).Include(x=>x.User).ToListAsync();

            var response = eventParticipants.Select(x => new GetEventParticipantsResponse()
            {
                Car = x.Car,
                Team = x.Team,
                Number = x.Number,
                ParticipantDto = _mapper.Map<Users,ParticipantDto>(x.User),
            }).ToList();
         
            return response;
        }
    }
}