using DixRacing.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.DataAccess.DbMappings
{
    public class EventCarDbMap : IEntityTypeConfiguration<EventCar>
    {
        public void Configure(EntityTypeBuilder<EventCar> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Event)
                    .WithMany(x=>x.EventCars)
                    .HasForeignKey(x=>x.CarId);
            builder.HasOne(x=>x.Car)
                    .WithMany(x=>x.EventCars)
                    .HasForeignKey(x=>x.EventId);
        }
    }
}