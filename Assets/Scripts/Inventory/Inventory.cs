using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Pickup pickUp;

    [SerializeField]
    private List<int> inventory = new List<int>();

    private InventoryGrid inventoryGrid;

    private int differentItems = 16;

    void Start()
    {
        pickUp = player.GetComponent<Pickup>();
        inventoryGrid = GetComponent<InventoryGrid>();

        pickUp.OnCollect += AddToInventory;
        pickUp.OnCollect += Instantiateitem;

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
