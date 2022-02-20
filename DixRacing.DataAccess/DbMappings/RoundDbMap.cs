using DixRacing.Domain.Rounds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DixRacing.DataAccess.DbMappings
{
    public class RoundDbMap : IEntityTypeConfiguration<Round>
    {
        public void Configure(EntityTypeBuilder<Round> builder)
        {
           builder.HasKey(x=>x.Id);
           builder.HasOne(x => x.Event)
                  .WithMany(x => x.Rounds)
                  .HasForeignKey(x=>x.EventId);        
        }
    }
}