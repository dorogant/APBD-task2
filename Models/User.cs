using APBD_TASK2.Enum;

namespace APBD_TASK2.Models;

public class User
{
    private static int _idCounter = 1;

    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public UserRole Role { get; set; }

    public User(string name, string surname, UserRole role)
    {
        Id = _idCounter++;
        Name = name;
        Surname = surname;
        Role = role;
    }
}