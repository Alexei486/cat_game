using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite itemIcon;
    public int maxStackSize;

    public Item(string name, Sprite icon, int stackSize)
    {
        itemName = name;
        itemIcon = icon;
        maxStackSize = stackSize;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Item item = (Item)obj;
        return itemName == item.itemName;
    }

    public override int GetHashCode()
    {
        return itemName.GetHashCode();
    }
}
