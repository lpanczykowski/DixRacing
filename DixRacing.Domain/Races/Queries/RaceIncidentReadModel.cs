using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Domain.Races.Queries
{
    public record RaceIncidentReadModel(int Id,
                                    int RaceId,
                                    int ReportedUserId,
                                    int UserId,
                                    string Description,
                                    int IsSolved,
                                    int Time,
                                    int Lap,
                                    int PointPenalty,
                                    int TimePenalty,
                                    string Penalty)
    {
        public RaceIncidentReadModel():this(default,default,default,default,default,default,default,default,default,default,default)
        {
        }
    }
}