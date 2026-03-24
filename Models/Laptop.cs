namespace APBD_TASK2.Models;

public class Laptop : Equipment
{
    public int RamGb { get; set; }
    public int SceenSize { get; set; }

    public Laptop(string name, int ramGb, int sceenSize)
        : base(name)
    {
        RamGb = ramGb;
        SceenSize = sceenSize;
    }
}