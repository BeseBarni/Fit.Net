using FitNet.Interfaces.Entity;
using System.ComponentModel.DataAnnotations;

namespace FitNet.Domain.Entities;
public class Workout : IDeletable
{
    [Required]
    public long Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string CodeName { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = null!;

    [MaxLength(500)]
    public string? Description { get; set; }

    public virtual ICollection<WorkoutGroup> WorkoutGroupList { get; set; } = new HashSet<WorkoutGroup>();
    public virtual ICollection<Exercise> ExerciseList { get; set; } = new HashSet<Exercise>();
    public bool IsDeleted { get; set; } = false;
}
