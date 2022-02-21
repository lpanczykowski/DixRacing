using DixRacing.Domain.Teams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DixRacing.DataAccess.DbMappings
{
    public class TeamDbMap : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasMany(x=>x.Participants)
                    .WithOne(x=>x.Team).HasForeignKey(x=>x.TeamId);
        }


    }
}