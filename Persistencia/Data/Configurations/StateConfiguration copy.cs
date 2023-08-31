using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

    public class StateConfiguration : IEntityTypeConfiguration <State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("State");
            builder.Property(p => p.StateName )
            .IsRequired()
            .HasMaxLength(30);

            builder.HasOne(p => p.Country)
            .WithMany(p => p.States)
            .HasForeignKey(p => p.IdCountryFk);
        }
    }
