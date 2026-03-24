using APBD_TASK2.Enum;

namespace APBD_TASK2.Models;

public abstract class Equipment
{
    private static int _idCounter = 1;
    public int Id { get; set; }
    public string Name { get; set; }
    public string Descrption { get; set; }
    public EquipmentStatus Status { get; set; }
    public DateTime AddedDat { get; set; }

    public Equipment( string name, string descrption = "")
    {
        Id = _idCounter++;
        Name = name;
        Descrption = descrption;
        Status = EquipmentStatus.Available;
        AddedDat = DateTime.Now;
    }
}