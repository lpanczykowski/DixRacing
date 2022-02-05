using DixRacing.Data.Entites;
using System;

namespace DixRacing.Data.Models.Response
{
    public class GetEventsWithActiveRound
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public int RoundCounter { get; set; }
        public Rounds ActiveRound { get; set; }
        public byte[] Photo { get; set; }
    }
}