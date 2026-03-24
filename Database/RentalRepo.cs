using APBD_TASK2.Interfaces;
using APBD_TASK2.Models;

namespace APBD_TASK2.Database;

public class RentalRepository : IRentalRepository
{
    private readonly Singleton _db = Singleton.Instance;

    public void Add(Rental rental)
    {
        _db.Rentals.Add(rental);
    }

    public List<Rental> GetAll()
    {
        return _db.Rentals;
    }

    public Rental? GetById(int id)
    {
        return _db.Rentals.FirstOrDefault(r => r.Id == id);
    }

    public void Update(Rental rental)
    {
        // Nothing special needed for in-memory storage
    }
}