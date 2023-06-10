using System.ComponentModel.DataAnnotations;

namespace WorkoutApp.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
    }
}