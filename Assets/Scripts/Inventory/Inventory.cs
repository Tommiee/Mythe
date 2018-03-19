using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<int> inventory = new List<int>();

    [SerializeField]
    private GameObject canvas;
    private ShowObject showObject;

    private int differentItems = 16;

    public GameObject item;

    void Start()
    {
        showObject = canvas.GetComponent<ShowObject>();

        for(var i = 0; i < differentItems; i++)
        {
            inventory.Add(0);
        }

        CollectedItem(item);
    }

    public void CollectedItem(GameObject item)
    {
        ObjectData obj = item.GetComponent<Collectable>().obj;

        showObject.ShowCollectable(obj);
        inventory[obj.id] += 1;
    }
	
}
