using APBD_TASK2.Enum;
using APBD_TASK2.Interfaces;

namespace APBD_TASK2.Models.Services;

public class EquipmentService : IEquipmentService
{
    private readonly IEquipmentRepository _equipmentRepository;

    public EquipmentService(IEquipmentRepository equipmentRepository)
    {
        _equipmentRepository = equipmentRepository;
    }

    public void AddEquipment(Equipment equipment)
    {
        _equipmentRepository.Add(equipment);
    }

    public List<Equipment> GetAllEquipment()
    {
        return _equipmentRepository.GetAll();
    }

    public List<Equipment> GetAllAvaliableEquipment()
    {
        return _equipmentRepository
            .GetAll()
            .Where(e => e.Status == EquipmentStatus.Available)
            .ToList();
    }

    public void MarkEquipmentAsUnavailable(int equipmentId)
    {
        var equipment = _equipmentRepository.GetById(equipmentId);

        if (equipment == null)
        {
            throw new Exception("Equipment not found.");
        }

        equipment.Status = EquipmentStatus.Unavailable;
        _equipmentRepository.Update(equipment);
    }
}