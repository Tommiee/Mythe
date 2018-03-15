using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_InputManager : MonoBehaviour {
    [SerializeField]
    private float threshold = 0.2f;
    private bool shiftpressed;

    public bool Up() {
        return Input.GetAxis("Vertical") > threshold;
    }
    public bool Down() {
        return Input.GetAxis("Vertical") < -threshold;
    }
    public bool Left() {
        return Input.GetAxis("Horizontal") < -threshold;
    }
    public bool Right() {
        return Input.GetAxis("Horizontal") > threshold;
    }
    public bool Shift() {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        { return true; } else { return false; }
    }
    public bool F() {
        if (Input.GetKey(KeyCode.F))
        { return true; } else { return false; }
    }
    public float GetXRot() {
        return Input.GetAxis("Mouse X");
    }
    public float GetYRot() {
        return -Input.GetAxis("Mouse Y");
    }
}
