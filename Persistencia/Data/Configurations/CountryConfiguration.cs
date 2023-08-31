using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

    public class CountryConfiguration : IEntityTypeConfiguration <Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");
            builder.Property(p => p.CountryName )
            .IsRequired()
            .HasMaxLength(30);
        }
    }
