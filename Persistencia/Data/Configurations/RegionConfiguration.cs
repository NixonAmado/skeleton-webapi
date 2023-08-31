using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

    public class RegionConfiguration : IEntityTypeConfiguration <Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("Region");
            builder.Property(p => p.RegionName )
            .IsRequired()
            .HasMaxLength(30);

            builder.HasOne(p => p.State)
            .WithMany(p => p.Regions)
            .HasForeignKey(p => p.IdStateFk);
        }
    }
