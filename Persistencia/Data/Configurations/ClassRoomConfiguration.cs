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

        
        }

  
}
