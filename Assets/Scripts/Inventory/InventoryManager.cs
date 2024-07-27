using UnityEngine;

using UnityEngine.UI; //тут кнопки и прочие UI
public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Button openInventoryButton;
    public Button closeInventoryButton;
    // Метод для открытия инвентаря

    void Start()
    {
        // Привязываем методы к кнопкам
        openInventoryButton.onClick.AddListener(OpenInventory);
        closeInventoryButton.onClick.AddListener(CloseInventory);
    }

    public void OpenInventory()
    {
        inventoryPanel.SetActive(true);
    }

    // Метод для закрытия инвентаря
    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
    }
}