using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

    public class RegistrationConfiguration : IEntityTypeConfiguration <Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {

            builder.HasKey(p => new{ p.IdClassRoomFk, p.IdPersonFk});
            builder.ToTable("Registration");

            builder.HasOne(p => p.ClassRoom )
            .WithMany(p=> p.Registrations)
            .HasForeignKey(p => p.IdClassRoomFk);

            builder.HasOne(p => p.Person)
            .WithMany(p => p.Registrations)
            .HasForeignKey(p => p.IdPersonFk);

        
        }
    }
