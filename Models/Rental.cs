namespace APBD_TASK2.Models;

public class Rental
{
    private static int _idCounter = 1;

    public int Id { get; set; }
    public User User { get; set; }
    public Equipment Equipment { get; set; }
    public DateTime From { get; set; }
    public DateTime DueTo { get; set; }
    public DateTime? Returned { get; set; }
    public double Penalty { get; set; }

    public Rental(User user, Equipment equipment, DateTime from, DateTime dueTo)
    {
        Id = _idCounter++;
        User = user;
        Equipment = equipment;
        From = from;
        DueTo = dueTo;
        Returned = null;
        Penalty = 0;
    }
}