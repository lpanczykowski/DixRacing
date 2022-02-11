using AutoMapper;
using DixRacing.Data;
using DixRacing.Data.Dtos;
using DixRacing.Data.Entites;
using DixRacing.Data.Interfaces;
using DixRacing.Data.Models.Response;
using DixRacing.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Services
{
    public class RoundService : IRoundService
    {
        private readonly DataContext _dataContext;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IRoundsRepository _roundsRepository;

        public RoundService(IRoundsRepository roundsRepository,
                            DataContext dataContext,
                            IEventRepository eventRepository,
                            IMapper mapper)
        {
            _roundsRepository = roundsRepository;
            _dataContext = dataContext;
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
        public async Task<ICollection<GetEventRoundsResponse>> GetEventRoundsResponsesByEventId(int eventId)
        {
            var EventRounds = await _dataContext.Rounds.Where(x => x.EventId == eventId).ToListAsync();

            var  response = _mapper.Map<ICollection<Rounds>, ICollection<GetEventRoundsResponse>>(EventRounds);
           
            return response;
        }

        public async Task<ICollection<GetRacesByRoundIdResponse>> GetRacesByRoundId(int roundId)
        {
            var RoundRaces= await _dataContext.Races.Where(x=>x.RoundId==roundId).ToListAsync();

            var response= _mapper.Map<ICollection<Races>,ICollection<GetRacesByRoundIdResponse>>(RoundRaces);
            
            return response;
        }
    }
}