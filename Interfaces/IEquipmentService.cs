using APBD_TASK2.Models;

namespace APBD_TASK2.Interfaces;

public interface IEquipmentService
{
    
    void AddEquipment(Equipment equipment);
    
    List<Equipment> GetAllEquipment(); //+display status
    List<Equipment> GetAllAvaliableEquipment(); //+display only avaliable equipment
    void MarkEquipmentAsUnavailable(int equipmentId);
}