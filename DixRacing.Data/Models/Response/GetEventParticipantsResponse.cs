using DixRacing.Data.Dtos;

namespace DixRacing.Data.Models.Response
{
    public class GetEventParticipantsResponse
    {
        public ParticipantDto ParticipantDto { get; set; }
        public int Number { get; set; }
        public string Team { get; set; }
        public int Car { get; set; }
    }
}