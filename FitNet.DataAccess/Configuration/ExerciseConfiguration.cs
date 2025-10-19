using FitNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitNet.DataAccess.Configuration;
internal class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.OwnsOne(p => p.Repetition);

        builder.HasOne(p => p.Equipment)
                .WithMany()
                .HasForeignKey(p => p.EquipmentId)
                .IsRequired(false);

        builder.HasOne(p => p.Workout)
                .WithMany()
                .HasForeignKey(p => p.WorkoutId);

        builder.HasOne(p => p.WorkoutGroup)
                .WithMany()
                .HasForeignKey(p => p.WorkoutGroupId)
                .IsRequired(false);

        builder
            .HasMany(p => p.ContraIndicationList)
            .WithMany(p => p.ExerciseList);
    }
}
