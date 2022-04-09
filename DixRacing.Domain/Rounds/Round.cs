using DixRacing.Domain.Events;
using DixRacing.Domain.Races;
using DixRacing.Domain.SharedKernel;
using DixRacing.Domain.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DixRacing.Domain.Rounds
{
    public class Round : BaseEntity
    {
        public int RoundNumber { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public ICollection<Race> Races { get; set; }
        public string ServerName { get; set; }
        public string ServerPassword { get; set; }
        public int TrackId { get; set; }
        [ForeignKey("TrackId")]
        public Track Track { get; set; }
        public DateTime RoundDay { get; set; }
        public bool IsActive { get; set; }

    }
}