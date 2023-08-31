using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

    public class ClassRoomConfiguration : IEntityTypeConfiguration <ClassRoom> 
    {
        public void Configure(EntityTypeBuilder<ClassRoom> builder)
        {
            
            builder.ToTable("ClassRoom");
        
            builder.Property(p => p.RoomName)
            .IsRequired()
            .HasMaxLength(20);
        
            builder.Property(p => p.Capacity)
            .IsRequired()
            .HasMaxLength(3)
            .HasColumnType("int");        

            builder.Property(p => p.Gender)
            .IsRequired()
            .HasMaxLength(15);//male//female//undefined

            builder.HasOne(p => p.Gender)
            .WithMany(p => p.ClassRooms)
            .HasForeignKey(p => p.IdGenderFk);            
        
            builder.HasOne(p => p.Country)
            .WithMany(p => p.ClassRooms)
            .HasForeignKey(p => p.IdCountryFk);

            builder.HasOne(p => p.ClassRoomType)
            .WithMany(p => p.ClassRooms)
            .HasForeignKey(p => p.IdClassRoomTypeFk);

            builder
            .HasMany(p => p.ClassRooms)
            .WithMany(p => p.ClassRooms)
            .UsingEntity<Registration>(
                j => j 
                    .HasOne(pt => pt.ClassRoom)
                    .WithMany(t => t.Registrations)
                    .HasForeignKey(pt => pt.IdClassRoomFk),

                j => j
                .HasOne(pt => pt.ClassRoom)
                .WithMany(p => p.Registrations)
                .HasForeignKey(pt => pt.IdClassRoomFk),

                j => j.HasKey(t => new{t.IdClassRoomFk, t.IdClassRoomFk})                
            );

        }

  
}
