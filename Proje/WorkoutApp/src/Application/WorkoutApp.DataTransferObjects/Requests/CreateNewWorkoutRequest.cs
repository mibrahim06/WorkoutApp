using System.ComponentModel.DataAnnotations;

namespace WorkoutApp.DataTransferObjects.Requests;

public class CreateNewWorkoutRequest
{
    [Required(ErrorMessage = "Egzersiz adı boş olamaz!")]
    [StringLength(50, ErrorMessage = "Egzersiz adı en fazla 50 karakter olabilir!")]
    [MinLength(3, ErrorMessage = "Egzersiz adı en az 3 karakter olmalıdır!")]
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public int? CategoryId { get; set; }
    public string? ImgUrl { get; set; } = "https://cdn.shopify.com/s/files/1/0145/1162/articles/He_is_lifting_weight_1024x1024.png?v=1636861979";
}