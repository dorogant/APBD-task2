using APBD_TASK2.Models;

namespace APBD_TASK2.Interfaces;

public interface IRentalService
{
    Rental RentEquipment(int userId, int equipmentId, int days);
    void ReturnEquipment(int rentalId);
    List<Rental> GetActiveRentalsForUser(int userId);
    List<Rental> GetOverdueRentals();
    string GenerateReport();
}