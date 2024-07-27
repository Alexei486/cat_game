using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Inventory inventory;
    public ItemDatabase itemDatabase;

    void Update()
    {
        // Пример добавления предмета при нажатии клавиши
        if (Input.GetKeyDown(KeyCode.P))
        {
            bool added = inventory.AddItemToInventory(itemDatabase.potion, 1);
            if (added)
            {
                Debug.Log("Potion added to inventory.");
            }
            else
            {
                Debug.Log("No space in inventory for potion.");
            }
            inventory.PrintInventoryState();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            bool added = inventory.AddItemToInventory(itemDatabase.sword, 1);
            if (added)
            {
                Debug.Log("Sword added to inventory.");
            }
            else
            {
                Debug.Log("No space in inventory for sword.");
            }
            inventory.PrintInventoryState();
        }
    }
}
