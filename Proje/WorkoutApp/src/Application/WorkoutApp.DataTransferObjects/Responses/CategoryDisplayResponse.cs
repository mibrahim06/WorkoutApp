namespace WorkoutApp.DataTransferObjects.Responses;

public class CategoryDisplayResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
}