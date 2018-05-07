using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public delegate void Collect(ObjectData data);
    public event Collect OnCollect;

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

                    OnCollect(obj);

                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}