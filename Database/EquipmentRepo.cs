using APBD_TASK2.Interfaces;
using APBD_TASK2.Models;

namespace APBD_TASK2.Database;

public class EquipmentRepo : IEquipmentRepository
{
    private readonly Singleton _db = Singleton.Instance;

    public void Add(Equipment equipment)
    {
        _db.Equipments.Add(equipment);
    }

    public List<Equipment> GetAll()
    {
        return _db.Equipments;
    }

    public Equipment? GetById(int id)
    {
        return _db.Equipments.FirstOrDefault(e => e.Id == id);
    }

    public void Update(Equipment equipment)
    {
        // For in-memory list, usually nothing special is needed
        // because the object reference is already updated.
    }
}