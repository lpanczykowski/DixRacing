using DixRacing.Domain.Races;
using DixRacing.Domain.Rounds;
using DixRacing.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Workers
{
    public class ReadResultService
    {
        private readonly IRepository<Round, int> _roundRepository;
        private readonly IRepository<Race, int> _raceRepository;

        public ReadResultService(IRepository<Round, int> roundRepository,
                                 IRepository<Race, int> raceRepository)
        {
            _roundRepository = roundRepository;
            _raceRepository = raceRepository;
        }


        public async Task ReadResultAccAsync(AccResult accResult)
        {
            var round = await _roundRepository.GetUniqueByPropertyAsync(x => x.ServerName == accResult.ServerName);
            var races = await _raceRepository.GetByPropertyAsync(x => x.RoundId == round.Id);
            if (races.Count() > 1)
            {
                
            }
            else
            {

            }

        }

    }
}