using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            //Many-to-many
            builder.HasMany(f => f.Passengers).WithMany(pa => pa.Flights)
                .UsingEntity(j => j.ToTable("Reservation"));// table d'association
                
            //One-to-many
            builder.HasOne(f=>f.Plane).WithMany(pl => pl.Flights)
                .HasForeignKey(f=>f.PlaneId)
                .OnDelete(DeleteBehavior.ClientSetNull);// clé entrangere set a null si entite associée est supprimée 
        }
    }
}
