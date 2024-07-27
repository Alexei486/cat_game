using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InventoryUIManager : MonoBehaviour
{
    public Inventory inventory;
    public GameObject slotPrefab;
    public Transform slotsParent;  // Убедитесь, что это InventoryPanel в Scroll View

    private List<GameObject> slotObjects = new List<GameObject>();

    void Start()
    {
        if (inventory == null)
        {
            Debug.LogError("Inventory reference is missing in InventoryUIManager.");
            return;
        }

        if (slotPrefab == null)
        {
            Debug.LogError("SlotPrefab reference is missing in InventoryUIManager.");
            return;
        }

        if (slotsParent == null)
        {
            Debug.LogError("SlotsParent reference is missing in InventoryUIManager.");
            return;
        }

        InitializeInventoryUI();
    }

    public void InitializeInventoryUI()
    {
        // Удаляем старые слоты (если есть)
        foreach (Transform child in slotsParent)
        {
            Destroy(child.gameObject);
        }

        slotObjects.Clear();

        // Создаем UI элементы для каждого слота
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            GameObject slotObject = Instantiate(slotPrefab, slotsParent);
            slotObjects.Add(slotObject);
            Debug.Log($"Created slot {i} at position {slotObject.transform.localPosition}");
        }

        // Обновляем UI
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        if (slotObjects == null || slotObjects.Count == 0)
        {
            Debug.LogError("Slot objects are not initialized.");
            return;
        }

        for (int i = 0; i < inventory.slots.Count; i++)
        {
            InventorySlot slot = inventory.slots[i];
            GameObject slotObject = slotObjects[i];

            Image icon = slotObject.transform.Find("Icon").GetComponent<Image>();
            TextMeshProUGUI countText = slotObject.transform.Find("Count").GetComponent<TextMeshProUGUI>();

            if (icon == null)
            {
                Debug.LogError($"Icon component is missing in slot prefab at index {i}.");
            }

            if (countText == null)
            {
                Debug.LogError($"Count component is missing in slot prefab at index {i}.");
            }

            if (slot.item != null)
            {
                Debug.Log($"Updating slot {i} with item {slot.item.itemName}");
                if (icon != null)
                {
                    icon.sprite = slot.item.itemIcon;
                    icon.enabled = true;
                    Debug.Log($"Set icon for slot {i} to {slot.item.itemIcon.name}");
                }

                if (countText != null)
                {
                    countText.text = slot.itemCount > 1 ? slot.itemCount.ToString() : "";
                }
            }
            else
            {
                Debug.Log($"Clearing slot {i}");
                if (icon != null)
                {
                    icon.enabled = false;
                }

                if (countText != null)
                {
                    countText.text = "";
                }
            }
        }
    }
}
