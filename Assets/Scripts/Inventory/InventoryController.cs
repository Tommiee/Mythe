using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InventoryEngine))]
public class InventoryController : MonoBehaviour
{
    public InventoryEngine inventoryEngine;
    //temp public
    [SerializeField]
    public List<int> inventory = new List<int>();
    private List<GameObject> inventoryUseable = new List<GameObject>();
    // temp public 
    [SerializeField]
    public List<GameObject> inventoryModels = new List<GameObject>();

    [SerializeField]
    private GameObject player;

    private int differentItems = 16;

    void Start()
    {
        inventoryEngine = GetComponent<InventoryEngine>();

        for (var i = 0; i < differentItems; i++)
        {
            inventory.Add(0);
        }
    }
    void Update()
    {
        inventoryEngine.SwitchController(player, this.gameObject);
//        inventoryEngine.AddDataTo();
//        inventoryEngine.DisplayItem();
    }
}
