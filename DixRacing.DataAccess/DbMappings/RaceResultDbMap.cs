using DixRacing.Domain.Races;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.DataAccess.DbMappings
{
    public class RaceResultDbMap : IEntityTypeConfiguration<RaceResult>
    {
        public void Configure(EntityTypeBuilder<RaceResult> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Race)
                   .WithMany(x => x.RaceResults)
                   .HasForeignKey(x => x.RaceId);
        }
    }
}