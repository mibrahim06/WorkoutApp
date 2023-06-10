namespace WorkoutApp.Entities;

public class Workout : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    public string? ImgUrl { get; set; } = "https://www.fitnesseducation.edu.au/wp-content/uploads/2020/10/Pushups.jpg";
}