using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    public ItemData item;
    public int itemCount;

    public bool AddItem(ItemData newItem, int count)
    {
        if (item == null)
        {
            item = newItem;
            itemCount = count;
            Debug.Log($"Added {count} {item.itemName}(s) to a new slot.");
            return true;
        }
        else if (item == newItem && itemCount + count <= item.maxStackSize)
        {
            itemCount += count;
            Debug.Log($"Added {count} more {item.itemName}(s) to the slot. Now it has {itemCount}.");
            return true;
        }
        else
        {
            Debug.Log($"Cannot add {count} {newItem.itemName}(s). Slot has {itemCount}, max is {newItem.maxStackSize}.");
            return false;
        }
    }

    public void RemoveItem(int count)
    {
        itemCount -= count;
        if (itemCount <= 0)
        {
            item = null;
            itemCount = 0;
        }
    }
}
