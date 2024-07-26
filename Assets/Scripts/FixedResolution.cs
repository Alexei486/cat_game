using UnityEngine;

public class FixedResolution : MonoBehaviour
{
    // ”становите желаемую ширину и высоту
    public int width = 1080;
    public int height = 2400;

    void Start()
    {
        // ”станавливаем разрешение и фиксируем его
        Screen.SetResolution(width, height, false);
        // ≈сли нужно, делаем окно не измен€емым
        Screen.fullScreenMode = FullScreenMode.Windowed;
    }
}