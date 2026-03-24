using APBD_TASK2.Models;

namespace APBD_TASK2.Interfaces;

public interface IEquipmentRepository
{
    void Add(Equipment equipment);
    List<Equipment> GetAll();
    Equipment? GetById(int id);
    void Update(Equipment equipment);
}