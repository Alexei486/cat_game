using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    public List<InventorySlot> slots;

    private InventoryUIManager uiManager;

    void Awake()
    {
        uiManager = FindObjectOfType<InventoryUIManager>();
        if (slots == null || slots.Count == 0)
        {
            InitializeSlots();
        }
    }

    void InitializeSlots()
    {
        slots = new List<InventorySlot>();
        for (int i = 0; i < 20; i++) // 20 слотов, измените это значение по необходимости
        {
            slots.Add(new InventorySlot());
        }

        Debug.Log("Inventory initialized with " + slots.Count + " slots.");
        uiManager.InitializeInventoryUI(); // Инициализация UI при создании слотов
    }

    public bool AddItemToInventory(ItemData item, int count)
    {
        Debug.Log($"Attempting to add {count} {item.itemName}(s) to inventory.");

        // Пытаемся добавить предмет в существующий слот
        foreach (InventorySlot slot in slots)
        {
            if (slot.item != null && slot.item == item && slot.itemCount + count <= slot.item.maxStackSize)
            {
                slot.itemCount += count;
                Debug.Log($"Added {count} {item.itemName}(s) to existing slot. Now it has {slot.itemCount}.");
                uiManager.UpdateInventoryUI(); // Обновляем UI
                return true;
            }
        }

        // Ищем пустой слот
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == null)
            {
                slot.item = item;
                slot.itemCount = count;
                Debug.Log($"Added {count} {item.itemName}(s) to new slot.");
                uiManager.UpdateInventoryUI(); // Обновляем UI
                return true;
            }
        }

        Debug.Log($"No space to add {count} {item.itemName}(s).");
        return false; // Нет места в инвентаре
    }

    public void PrintInventoryState()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item != null)
            {
                Debug.Log($"Slot {i}: {slots[i].item.itemName} x {slots[i].itemCount}");
            }
            else
            {
                Debug.Log($"Slot {i}: Empty");
            }
        }
    }
}
