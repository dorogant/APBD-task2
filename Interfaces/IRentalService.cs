using APBD_TASK2.Models;

namespace APBD_TASK2.Interfaces;

internal interface IRentalService
{
    void AddUser(User user);
    void AddEquipment(Equipment equipment);

    List<Equipment> GetAllEquipment();
    List<Equipment> GetAllAvaliableEquipment();

    Rental RentEquipment(int userId, int equipmentId, int days);

    string GenerateReport();

} 