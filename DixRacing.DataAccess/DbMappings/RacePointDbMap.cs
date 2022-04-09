using DixRacing.Domain.Races;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.DataAccess.DbMappings
{
    public class RacePointDbMap : IEntityTypeConfiguration<RacePoint>
    {
        public void Configure(EntityTypeBuilder<RacePoint> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Race)
                   .WithMany(x => x.RacePoints)
                   .HasForeignKey(x => x.RaceId);
        }
    }
}