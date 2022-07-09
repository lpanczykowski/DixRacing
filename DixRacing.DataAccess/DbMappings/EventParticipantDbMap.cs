using DixRacing.Domain.EventParticipants;
using DixRacing.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DixRacing.DataAccess.DbMappings
{
    public class EventParticipantDbMap : IEntityTypeConfiguration<EventParticipant>
    {
        public void Configure(EntityTypeBuilder<EventParticipant> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasOne(x=>x.Event)
                   .WithMany(x=>x.EventParticipants)
                   .HasForeignKey(x=>x.EventId);
        }
    }
}