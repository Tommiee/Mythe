using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryEngine : MonoBehaviour
{
    private InputManager inputManager;

    void Start()
    {
        inputManager = GetComponent<InputManager>();

        this.GetComponentInChildren<Camera>().enabled = false;
    }

    public void AddDataTo(ObjectData item, List<int> list)
    {
        list[item.id] += 1;
    }

    public void DisplayItem(ObjectData item, List<GameObject> list)
    {

        list[item.id].SetActive(true);
    }

    public void SwitchController(GameObject to, GameObject from)
    {
        if (inputManager.TabPress())
        {
            to.GetComponentInChildren<Camera>().enabled = true;
            to.gameObject.SetActive(true);

            from.GetComponentInChildren<Camera>().enabled = false;
        }
    }
}
