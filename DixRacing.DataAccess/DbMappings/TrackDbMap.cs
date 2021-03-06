using DixRacing.Domain.Tracks;
using DixRacing.Domain.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DixRacing.DataAccess.DbMappings
{
    public class TrackDbMap : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasOne(x => x.Game).WithMany(x => x.Tracks).HasForeignKey(x => x.GameId);
        }
    }
}