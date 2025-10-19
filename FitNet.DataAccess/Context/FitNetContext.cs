using FitNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FitNet.DataAccess.Context;
public class FitNetContext : DbContext
{
    public FitNetContext(DbContextOptions options) : base(options)
    {
    }

    protected FitNetContext()
    {
    }

    public DbSet<Category> Category { get; set; }
    public DbSet<ContraIndication> ContraIndication { get; set; }
    public DbSet<Equipment> Equipment { get; set; }
    public DbSet<Exercise> Exercise { get; set; }
    public DbSet<Measurement> Measurement { get; set; }
    public DbSet<Workout> Workout { get; set; }
    public DbSet<WorkoutGroup> WorkoutGroup { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
