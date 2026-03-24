using APBD_TASK2.Models;

namespace APBD_TASK2.Interfaces;

public interface IUserService
{
    void AddUser(User user);
    List<User> GetAllUsers();
    User? GetUserById(int id);
}