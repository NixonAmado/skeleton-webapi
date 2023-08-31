using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

    public class PersonTypeConfiguration : IEntityTypeConfiguration <PersonType>
    {
        public void Configure(EntityTypeBuilder<PersonType> builder)
        {
            builder.ToTable("PersonType");
            builder.Property(p => p.Description )
            .IsRequired()
            .HasMaxLength(30);

        }
    }
