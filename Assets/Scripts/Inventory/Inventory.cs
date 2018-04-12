using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<int> inventory = new List<int>();
    private List<GameObject> inventoryUseable = new List<GameObject>();
    [SerializeField]
    private List<GameObject> inventoryModels = new List<GameObject>();

    private int differentItems = 16;

    void Start()
    {
        this.GetComponentInChildren<Camera>().enabled = false;

        FillInventory(differentItems);
    }

    void FillInventory(int amount)
    {
        for (var i = 0; i < amount; i++)
        {
            inventory.Add(0);
        }
    }

    public void DisplayItem(ObjectData item)
    {
        inventoryModels[item.id].SetActive(true);
//        item.model;
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
