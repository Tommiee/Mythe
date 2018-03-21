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
    private ShowObject showObject;

    private int differentItems = 16;

    void Start()
    {
        showObject = canvas.GetComponent<ShowObject>();

        for(var i = 0; i < differentItems; i++)
        {
            inventory.Add(0);
        }
    }

    public void CollectedItem(ObjectData item)
    {
        showObject.ShowCollectable(item);
        inventory[item.id] += 1;
    }
	
}
