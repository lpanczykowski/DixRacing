using AutoMapper;
using DixRacing.Core.Models.Response;
using DixRacing.Data;
using DixRacing.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Services
{
    public class RaceResultsService : IRaceResultsService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public RaceResultsService(DataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<ICollection<RaceResultsResponse>> FindRaceResultsByRaceId(int raceId)
        {
            var raceResults = await _dataContext.RaceResults.Where(x => x.RaceId == raceId).Include(x => x.User).ToListAsync();

            var raceResultsResponse = _mapper.Map<List<RaceResultsResponse>>(raceResults);
            return raceResultsResponse;

        }
    }
}