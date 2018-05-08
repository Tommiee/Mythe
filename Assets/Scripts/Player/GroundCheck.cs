using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
    public bool CheckGround(string targetTag)
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 5f) && hit.transform.tag == targetTag) //raycast acid floor
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
