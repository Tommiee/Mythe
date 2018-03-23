using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_CameraFPSRotation : MonoBehaviour {

	[SerializeField]
	float cameraSpeed;
	[SerializeField]
	GameObject parent;


	// Use this for initialization
	void Start () {
		//Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.rotation.x > -80 && transform.rotation.x < 80)
		this.transform.Rotate(GetYRot(), 0, 0);
        parent.transform.Rotate(0, GetXRot(), 0);
	}



	public float GetXRot()
	{
		return Input.GetAxis("Mouse X") * cameraSpeed;
	}
	public float GetYRot()
	{
		return -Input.GetAxis("Mouse Y") * cameraSpeed;
	}
}

/*
 * if (transform.eulerAngles.x < minAngle)
        {
            print("rotating to " + minAngle);
            transform.rotation = Quaternion.Euler(new Vector3(minAngle, 0, 0));
        }
        if (transform.eulerAngles.x > maxAngle)
        {
            print("rotating to " + maxAngle);
            transform.rotation = Quaternion.Euler(new Vector3(maxAngle, 0, 0));
        }
        if (transform.eulerAngles.x + _rotation.x >= minAngle && transform.eulerAngles.x + _rotation.x <= maxAngle)
        {
            transform.Rotate(_rotation);
        }
   */