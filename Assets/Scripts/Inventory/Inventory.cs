using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void Collect(ObjectData data);

    public event Collect OnAdd;
    public event Collect OnRemove;

    [SerializeField]
    private List<int> inventory = new List<int>();

    private int differentItems = 16;

    void Start()
    {
        for(var i = 0; i < differentItems; i++)
        {
            inventory.Add(0);
        }
    }

    public void AddToInventory(ObjectData item)
    {
        inventory[item.id] += 1;
        OnAdd(item);
    }

    public void RemoveFromInventory(ObjectData item)
    {
        inventory[item.id] -= 1;
        OnRemove(item);
    }

}
