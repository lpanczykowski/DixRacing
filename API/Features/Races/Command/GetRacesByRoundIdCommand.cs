using MediatR;
using System;
using System.Collections.Generic;

namespace API.Features.Races
{
    public record GetRacesByRoundIdCommand(int RoundId) : IRequest<IEnumerable<GetRacesByRoundIdResponse>>;
    public record GetRacesByRoundIdResponse(int id, DateTime preqDate,DateTime practiceDate, int practiceLength, DateTime qualiDate,int qualiLength,DateTime raceDate,int raceLength,int RoundId){
        public GetRacesByRoundIdResponse() :this(default,default,default,default,default,default,default,default,default)
        {
            
        }
    };
}