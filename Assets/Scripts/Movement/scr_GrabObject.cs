using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_GrabObject : MonoBehaviour {
    public GameObject PickUp(float range)
    {
        //Finds the camera, and it's forward facing vector.
        Camera cam = gameObject.GetComponentInChildren<Camera>();
        Vector3 fwd = cam.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, fwd, out hit, range))
        {
            Debug.DrawRay(cam.transform.position,fwd,Color.red,1,false);
            return hit.transform.gameObject;
        }
        else
        {
            return null;
        }
    }
}