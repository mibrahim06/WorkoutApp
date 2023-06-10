using System.ComponentModel.DataAnnotations;

namespace WorkoutApp.Entities;

public class Category : IEntity
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
  
}