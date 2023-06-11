using WorkoutApp.Entities;

namespace WorkoutApp.Services;

public interface IUserService
{
    User Authenticate(string username, string password);
}