using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_CameraFPSRotation : MonoBehaviour {

	[SerializeField]
	private float cameraSpeed = 2;
    [SerializeField]
    private float limitAngle = 80f;
	[SerializeField]
	private GameObject parent;

    private float cameraRotationX = 0f;
    private float currentCamRotX = 0;
    private Vector3 rotation = Vector3.zero;

    // Use this for initialization
    void Start () {
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        //float _cameraRotationX = GetXRot() * cameraSpeed;
        
        parent.transform.Rotate(0, GetYRot(), 0);
        this.transform.Rotate(GetXRot(), 0, 0);

        //print(this.transform.localEulerAngles.x);

        rotation = new Vector3(Mathf.Clamp(this.transform.localEulerAngles.x, -limitAngle, limitAngle), 0, 0);
        print(rotation.x);
        if(rotation.x >= 0)
        {
            this.transform.localEulerAngles = rotation;
        } else
        {
            this.transform.localEulerAngles = new Vector3(360 - rotation.x, 360 - rotation.y, 360 - rotation.z);
        }
        
        /*
        rotation = new Vector3(0f, GetYRot(), 0f) * cameraSpeed;
        parent.GetComponent<Rigidbody>().MoveRotation(transform.rotation * Quaternion.Euler(rotation));
        currentCamRotX -= cameraRotationX;
        currentCamRotX = Mathf.Clamp(currentCamRotX, -limitAngle, limitAngle);
        //print("cam transform localEulerangles: " + this.transform.localEulerAngles.x);
        //print("currentCamRotX: " + currentCamRotX);
        //print("cameraRotationX: " + cameraRotationX);
        this.transform.localEulerAngles = new Vector3(currentCamRotX, 0f, 0f);
        */
    }

	public float GetYRot()
	{
		return Input.GetAxis("Mouse X") * cameraSpeed;
	}
	public float GetXRot()
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

        void performRotation()
    {
        rb.MoveRotation(transform.rotation * Quaternion.Euler(rotation));
        if(cam != null)
        {
            currentCamRotX -= cameraRotationX;
            currentCamRotX = Mathf.Clamp(currentCamRotX, -camRotLimit, camRotLimit);

            cam.transform.localEulerAngles = new Vector3(currentCamRotX, 0f, 0f);
        }
    }
    
   */
