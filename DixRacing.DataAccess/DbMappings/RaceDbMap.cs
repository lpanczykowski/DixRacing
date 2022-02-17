using DixRacing.Domain.Races;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DixRacing.DataAccess.DbMappings
{
    public class RaceDbMap : IEntityTypeConfiguration<Race>

    {
        public void Configure(EntityTypeBuilder<Race> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasOne(x => x.Round)
                  .WithMany(x => x.Races)
                  .HasForeignKey(x=>x.RoundId);
        }
    }
}