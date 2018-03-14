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
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		this.transform.Rotate(GetYRot(), 0, 0);
		parent.transform.Rotate(0, GetYRot(), 0);
		


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
