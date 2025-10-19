using FitNet.Interfaces.Entity;
using System.ComponentModel.DataAnnotations;

namespace FitNet.Domain.Entities;
public class WorkoutGroup : IDeletable
{
    [Required]
    public long Id { get; set; }

    [Required]
    public long WorkoutId { get; set; }
    public virtual Workout Workout { get; set; } = null!;

    public virtual ICollection<Exercise> ExerciseList { get; set; } = new HashSet<Exercise>();

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = null!;
    public bool IsDeleted { get; set; } = false;
}
