using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

    public class GenderConfiguration : IEntityTypeConfiguration <Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable("Gender");
            builder.Property(p => p.Description )
            .IsRequired()
            .HasMaxLength(30);
        }
    }
