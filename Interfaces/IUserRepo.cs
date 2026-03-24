using APBD_TASK2.Models;

namespace APBD_TASK2.Interfaces;

public interface IUserRepository
{
    void Add(User user);
    List<User> GetAll();
    User? GetById(int id);
}