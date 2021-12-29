using DixRacing.Data.Entites;
using DixRacing.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Repositories
{
    public class RoundsRepository :  Repository<Rounds>, IRoundsRepository
    {
        private readonly DataContext _dataContext;

        public RoundsRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Rounds> FindRoundByTrackAndDate(string trackName, DateTime roundDate)
        {
            var round = await _dataContext.Rounds.Where(x=>x.Track.Name == trackName && x.RoundDay.Date == roundDate.Date).Include(x=>x.Races).FirstOrDefaultAsync();
            return round;
        }
    }
}