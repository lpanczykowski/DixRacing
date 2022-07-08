using AutoMapper;
using DixRacing.Domain.Events;
using DixRacing.Domain.SharedKernel;
using DixRacing.Domain.Utility;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Dropdowns.Queries.Cars
{
    public class GetDropdownCarsHandler : IRequestHandler<GetDropdownCarsRequest, GetDropdownResponse>
    {
        private readonly IRepository<Car> _carRepository;
        private readonly IMapper _mapper;
    private readonly IRepository<Event> _eventRepository;
        public GetDropdownCarsHandler(IRepository<Car> carRepository,IRepository<Event> eventRepository, IMapper mapper)
        {
      _eventRepository = eventRepository;
            _mapper = mapper;
            _carRepository = carRepository;
        }

        public async Task<GetDropdownResponse> Handle(GetDropdownCarsRequest request, CancellationToken cancellationToken)
        {
            var events = await _eventRepository.GetByIdAsync(request.eventId);
            var gameId = events.GameId;
            var cars= await _carRepository.GetByPropertyAsync(x=>x.EventId==request.eventId && x.GameId==gameId);
            var result =  _mapper.Map<IEnumerable<Car>,IEnumerable<DropdownDto>>(cars);
            return new GetDropdownResponse(result);
        }
    }
}