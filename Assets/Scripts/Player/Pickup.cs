using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    private DisplayItemInfo showObject;

    [SerializeField]
    private GameObject inventory;
    private Inventory invScript;

    void Start()
    {
        showObject = canvas.GetComponent<DisplayItemInfo>();
        invScript = inventory.GetComponent<Inventory>();
    }

    public void CollectItem(float range, bool when)
    {
        Camera cam = gameObject.GetComponentInChildren<Camera>();
        Vector3 fwd = cam.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, fwd, out hit, 4f))
        {
            if (when)
            {
                Collectable collectable;
                if (collectable = hit.transform.gameObject.GetComponent<Collectable>())
                {
                    ObjectData obj = hit.transform.gameObject.GetComponent<Collectable>().obj;

                    showObject.ShowCollectable(obj);

                    invScript.AddToInventory(obj);
                    invScript.DisplayItem(obj);

                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}