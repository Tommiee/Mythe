using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InventoryEngine))]
public class InventoryController : MonoBehaviour
{
    private InventoryEngine inventoryEngine;

    [SerializeField]
    private List<int> inventory = new List<int>();
    private List<GameObject> inventoryUseable = new List<GameObject>();

    [SerializeField]
    private GameObject player;

    private int differentItems = 16;

    void Start()
    {
        this.GetComponentInChildren<Camera>().enabled = false;
        this.gameObject.SetActive(false);

        inventoryEngine = this.GetComponent<InventoryEngine>();

        for (var i = 0; i < differentItems; i++)
        {
            inventory.Add(0);
        }
    }
    void Update()
    {
        print("hi");
        inventoryEngine.SwitchController(player, this.gameObject);
    }
}
