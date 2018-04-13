using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<int> inventory = new List<int>();
    private List<GameObject> inventoryUseable = new List<GameObject>();
    //temp
    [SerializeField]
    private List<GameObject> invModels = new List<GameObject>();

    [SerializeField]
    private GameObject canvas;
    private DisplayItemInfo showObject;

    private int differentItems = 16;

    void Start()
    {
        showObject = canvas.GetComponent<DisplayItemInfo>();

        for(var i = 0; i < differentItems; i++)
        {
            inventory.Add(0);
        }
    }

    public void AddToInventory(ObjectData item)
    {
        inventory[item.id] += 1;
    }

    public void RemoveFromInventory(ObjectData item)
    {
        inventory[item.id] -= 1;
    }

    public void DisplayItem(ObjectData item)
    {
        invModels[item.id].SetActive(true);
    }

    public void CollectedItem(ObjectData item)
    {
        showObject.ShowCollectable(item);
        inventory[item.id] += 1;
    }
	
}
