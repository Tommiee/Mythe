using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<int> inventory = new List<int>();
    private List<GameObject> inventoryUseable = new List<GameObject>();

    [SerializeField]
    private GameObject canvas;
    private DisplayItemInfo showObject;
    //temp public
    public InventoryGrid inventoryGrid;

    private int differentItems = 16;

    void Start()
    {
        showObject = canvas.GetComponent<DisplayItemInfo>();
        inventoryGrid = GetComponent<InventoryGrid>();

        for(var i = 0; i < differentItems; i++)
        {
            inventory.Add(0);
        }
    }

    public void Instantiateitem(ObjectData item)
    {
        Instantiate(item.model, inventoryGrid.GetPosInv(), Quaternion.identity);
    }

    public void AddToInventory(ObjectData item)
    {
        inventory[item.id] += 1;
    }

    public void RemoveFromInventory(ObjectData item)
    {
        inventory[item.id] -= 1;
    }

}
