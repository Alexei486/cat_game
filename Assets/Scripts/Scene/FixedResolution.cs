using UnityEngine;

public class FixedResolution : MonoBehaviour
{
    // ���������� �������� ������ � ������
    public int width = 1080;
    public int height = 2400;

    void Start()
    {
        // ������������� ���������� � ��������� ���
        Screen.SetResolution(width, height, false);
        // ���� �����, ������ ���� �� ����������
        Screen.fullScreenMode = FullScreenMode.Windowed;
    }
}