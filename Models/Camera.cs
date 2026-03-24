namespace APBD_TASK2.Models;

public class Camera : Equipment
{
    public int Megapixels { get; set; }
    public int Zoom { get; set; }

    public Camera(string name, int megapixels, int zoom)
        : base(name)
    {
        Megapixels = megapixels;
        Zoom = zoom;
    }
}