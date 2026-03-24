using APBD_TASK2.Interfaces;
using APBD_TASK2.Models;

namespace APBD_TASK2.Database;

public class UserRepository : IUserRepository
{
    private readonly Singleton _db = Singleton.Instance;

    public void Add(User user)
    {
        _db.Users.Add(user);
    }

    public List<User> GetAll()
    {
        return _db.Users;
    }

    public User? GetById(int id)
    {
        return _db.Users.FirstOrDefault(u => u.Id == id);
    }
}