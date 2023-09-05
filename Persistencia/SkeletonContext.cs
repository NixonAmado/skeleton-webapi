using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data;
public class SkeletonContext : DbContext
{
    public SkeletonContext(DbContextOptions<SkeletonContext> options) : base(options) 
    {
    }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<PersonType> PersonTypes { get; set; }
    public DbSet<Registration> Registrations { get; set; }
    public DbSet<ClassRoom> ClassRooms { get; set; }
    public DbSet<TrainerClassRoom> TrainerClassRooms { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Region> Regions { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder
        
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

