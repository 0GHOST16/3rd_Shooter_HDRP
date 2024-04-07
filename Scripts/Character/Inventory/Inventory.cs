using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventoryItems;
    private int currentItemIndex = 0;

    void Update()
    {
        // activarea/dezactivarea obiectelor
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ToggleInventoryItem(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ToggleInventoryItem(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ToggleInventoryItem(2);
        }
    }

    void ToggleInventoryItem(int itemIndex)
    {
        // verificam daca indexul exista
        if (itemIndex >= 0 && itemIndex < inventoryItems.Length)
        {
            // dezactivam obiectul curent
            inventoryItems[currentItemIndex].SetActive(false);

            // activam indexul curent
            currentItemIndex = itemIndex;

            // activam obiectul nou
            inventoryItems[currentItemIndex].SetActive(true);
        }
    }
}
