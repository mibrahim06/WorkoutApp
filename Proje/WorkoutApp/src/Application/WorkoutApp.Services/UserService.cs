using WorkoutApp.Entities;

namespace WorkoutApp.Services;

public class UserService : IUserService
{
    // this is fake data for now for testing purposes
    // @TODO: replace with real data
    private List<User> _users;
    public UserService()
    {
        _users = new()
        {
            new()
            {
                Id = 1, Email = "test@gmail.com", Name = "admin", Password = "abcd", Role = "Admin",
                Username = "admin"
            },
            new()
            {
                Id = 2, Email = "test2@gmail.com", Name = "user", Password = "abcd", Role = "User",
                Username = "user"
            },
            new User()
            {
                Id =3, Email = "abc@gmail.com", Name = "editor", Password = "abcd", Role = "Editor",
                Username = "editor"
            }
        };
    }
    public User? Authenticate(string username, string password)
    {
        var user = _users.SingleOrDefault(u => u.Username == username && u.Password == password);
        if (user == null)
        {
            return null;
        }

        return user;
    }
}