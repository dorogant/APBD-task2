using APBD_TASK2.Interfaces;

namespace APBD_TASK2.Models.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void AddUser(User user)
    {
        _userRepository.Add(user);
    }

    public List<User> GetAllUsers()
    {
        return _userRepository.GetAll();
    }

    public User? GetUserById(int id)
    {
        return _userRepository.GetById(id);
    }
}