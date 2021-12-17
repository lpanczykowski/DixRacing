using DixRacing.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class RoundsController
    {
        private readonly IRoundsRepository _roundsRepository;

        public RoundsController(IRoundsRepository roundsRepository)
        {
            _roundsRepository = roundsRepository;
        }
        
    }
}