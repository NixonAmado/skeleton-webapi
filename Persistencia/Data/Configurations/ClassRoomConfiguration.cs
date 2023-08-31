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

            builder
            .HasMany(p => p.Persons)
            .WithMany(p => p.ClassRooms)
            .UsingEntity<TrainerClassRoom>(

                j => j
                .HasOne(pt => pt.Person)
                .WithMany(p => p.TrainerClassRooms)
                .HasForeignKey(pt => pt.IdPersonFk),


                j => j 
                    .HasOne(pt => pt.ClassRoom)
                    .WithMany(t => t.TrainerClassRooms)
                    .HasForeignKey(pt => pt.IdClassRoomFk),

                j => j.HasKey(t => new{t.IdPersonFk, t.IdClassRoomFk})                
            );
        }

  
}
