using UnityEngine;

using UnityEngine.UI; //��� ������ � ������ UI
public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Button openInventoryButton;
    public Button closeInventoryButton;
    // ����� ��� �������� ���������

    void Start()
    {
        // ����������� ������ � �������
        openInventoryButton.onClick.AddListener(OpenInventory);
        closeInventoryButton.onClick.AddListener(CloseInventory);
    }

    public void OpenInventory()
    {
        inventoryPanel.SetActive(true);
    }

    // ����� ��� �������� ���������
    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
    }
}