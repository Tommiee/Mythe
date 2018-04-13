using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_CameraFPSRotation : MonoBehaviour
{

    [SerializeField]
    float cameraSpeed;
    [SerializeField]
    GameObject parent;
    [SerializeField]
    private float angleLimit = 60;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = transform.rotation.eulerAngles + new Vector3(GetYRot(), 0f, 0f);
        rot.x = ClampAngle(rot.x, -angleLimit, angleLimit);
        transform.eulerAngles = rot;
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

    float ClampAngle(float angle, float from, float to)
    {
        if (angle < 0f) angle = 360 + angle;
        if (angle > 180f) return Mathf.Max(angle, 360 + from);
        return Mathf.Min(angle, to);
    }
}