using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    private GameObject _inventory;
    private Inventory inventory;

    void Start() { inventory = _inventory.GetComponent<Inventory>(); }

    public void CollectItem(float range, bool when)
    {
        Camera cam = gameObject.GetComponentInChildren<Camera>();
        Vector3 fwd = cam.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, fwd, out hit, 12f))
        {
            if (when)
            {
                Collectable collectable = hit.transform.gameObject.GetComponent<Collectable>();
                if (collectable != null)
                {
                    ObjectData obj = collectable.obj;

                    inventory.AddToInventory(obj);

                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}