using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

    public class PersonConfiguration : IEntityTypeConfiguration <Person> 
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            
            builder.ToTable("Person");
        
            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(20);
        
            builder.Property(p => p.Surname)
            .IsRequired()
            .HasMaxLength(20);        

            builder.Property(p => p.Gender)
            .IsRequired()
            .HasMaxLength(15);//male//female//undefined

            builder.HasOne(p => p.Gender)
            .WithMany(p => p.Persons)
            .HasForeignKey(p => p.IdGenderFk);            
        
            builder.HasOne(p => p.Country)
            .WithMany(p => p.Persons)
            .HasForeignKey(p => p.IdCountryFk);

            builder.HasOne(p => p.PersonType)
            .WithMany(p => p.Persons)
            .HasForeignKey(p => p.IdPersonTypeFk);

            builder
            .HasMany(p => p.ClassRooms)
            .WithMany(p => p.Persons)
            .UsingEntity<Registration>(

                j => j
                .HasOne(pt => pt.ClassRoom)
                .WithMany(p => p.Registrations)
                .HasForeignKey(pt => pt.IdClassRoomFk),

                j => j 
                    .HasOne(pt => pt.Person)
                    .WithMany(t => t.Registrations)
                    .HasForeignKey(pt => pt.IdPersonFk),


                j => j.HasKey(t => new{t.IdPersonFk, t.IdClassRoomFk})                
            );

            
        }
}
