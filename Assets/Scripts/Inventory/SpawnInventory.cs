using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInventory : MonoBehaviour
{
    private InventoryGrid inventoryGrid;
    private Inventory inventory;

    private void Start()
    {
        inventoryGrid = GetComponent<InventoryGrid>();
        inventory = GetComponent<Inventory>();

        inventory.OnAdd += Instantiateitem;
    }

    public void Instantiateitem(ObjectData item)
    {
        Instantiate(item.model, inventoryGrid.GetPosInv(), Quaternion.identity);
    }

    public void MoveToInventory(GameObject item)
    {
        item.transform.position = inventoryGrid.GetPosInv();
    }

    public void MoveToCraft(GameObject item)
    {
        item.transform.position = inventoryGrid.GetPosCraft();
    }
}
