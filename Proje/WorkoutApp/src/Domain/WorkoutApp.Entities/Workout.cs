using System.ComponentModel.DataAnnotations;

namespace WorkoutApp.Entities;

public class Workout : IEntity
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    public string? ImgUrl { get; set; } = "https://cdn.shopify.com/s/files/1/0145/1162/articles/He_is_lifting_weight_1024x1024.png?v=1636861979";
}