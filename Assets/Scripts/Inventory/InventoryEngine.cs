using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryEngine : MonoBehaviour
{
    private InputManager inputManager;

    void Start()
    {
        inputManager = GetComponent<InputManager>();
    }

    public void AddDataTo(ObjectData item, List<int> list)
    {
        list[item.id] += 1;
    }

    public void SwitchController(GameObject to, GameObject from)
    {
        if (inputManager.FPress())
        {
            to.GetComponentInChildren<Camera>().enabled = true;
            to.SetActive(true);

            from.GetComponentInChildren<Camera>().enabled = false;
            from.gameObject.SetActive(false);
        }
    }
}
