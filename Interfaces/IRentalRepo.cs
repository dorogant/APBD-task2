using APBD_TASK2.Models;

namespace APBD_TASK2.Interfaces;

public interface IRentalRepository
{
    void Add(Rental rental);
    List<Rental> GetAll();
    Rental? GetById(int id);
    void Update(Rental rental);
}