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
            
            builder.HasOne(p => p.Gender)
            .WithMany(p => p.Persons)
            .HasForeignKey(p => p.IdGenderFk);            
        
            builder.HasOne(p => p.Country)
            .WithMany(p => p.Persons)
            .HasForeignKey(p => p.IdCountryFk);

            builder.HasOne(p => p.PersonType)
            .WithMany(p => p.Persons)
            .HasForeignKey(p => p.IdPersonTypeFk);


            builder.HasOne(p => p.Region)
            .WithMany(p => p.Persons)
            .HasForeignKey(p => p.IdRegionFk);


            builder
            .HasMany(p => p.ClassRooms)
            .WithMany(p => p.Persons)
            .UsingEntity<TrainerClassRoom>(

                j => j
                .HasOne(pt => pt.ClassRoom)
                .WithMany(p => p.TrainerClassRooms)
                .HasForeignKey(pt => pt.IdClassRoomFk),

                j => j 
                    .HasOne(pt => pt.Person)
                    .WithMany(t => t.TrainerClassRooms)
                    .HasForeignKey(pt => pt.IdPersonFk),


                j => j.HasKey(t => new{t.IdPersonFk, t.IdClassRoomFk})                
            );

            
        }
}
