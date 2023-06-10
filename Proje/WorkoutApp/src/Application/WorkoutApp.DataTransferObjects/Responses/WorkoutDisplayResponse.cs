namespace WorkoutApp.DataTransferObjects.Responses;

public class WorkoutDisplayResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? ImgUrl { get; set; }
}