using FitNet.Interfaces.Entity;
using System.ComponentModel.DataAnnotations;

namespace FitNet.Domain.Entities;
public class ContraIndication : IDeletable
{
    [Required]
    public long Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Equipment> EquipmentList { get; set; } = new HashSet<Equipment>();
    public virtual ICollection<Exercise> ExerciseList { get; set; } = new HashSet<Exercise>();
    public bool IsDeleted { get; set; } = false;
}
