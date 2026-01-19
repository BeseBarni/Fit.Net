using FitNet.Domain.Entities;
using FitNet.Interfaces.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
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

        ApplyGlobalFilters(modelBuilder);
    }

    private void ApplyGlobalFilters(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(IDeletable).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var property = Expression.Property(parameter, nameof(IDeletable.IsDeleted));
                var filter = Expression.Lambda(Expression.Equal(property, Expression.Constant(false)), parameter);
                
                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
            }
        }
    }
}
