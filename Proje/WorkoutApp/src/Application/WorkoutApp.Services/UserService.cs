using WorkoutApp.Entities;
using WorkoutApp.Infrastructure.Repositories;

namespace WorkoutApp.Services;

public class UserService : IUserService
{
    // this is fake data for now for testing purposes
    // @TODO: replace with real data
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public User? Authenticate(string username, string password)
    {
        var user = _userRepository.GetUserByUsernamePasswordAsync(username, password).Result;
        if (user == null)
        {
            return null;
        }
        return user;
    }
}