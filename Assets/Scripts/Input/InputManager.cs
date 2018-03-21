using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float ZMov()
    {
        return Input.GetAxisRaw(Strings.Movement.VERTICAL);
    }
    public float XMov()
    {
        return Input.GetAxisRaw(Strings.Movement.HORIZONTAL);
    }
    public float YRot()
    {
        return Input.GetAxis(Strings.Movement.MOUSE_X);
    }
    public float XRot()
    {
        return Input.GetAxis(Strings.Movement.MOUSE_Y);
    }
    public float Interact()
    {
        return Input.GetAxis(Strings.Movement.INTERACT);
    }
    public float Inventory()
    {
        return Input.GetAxis(Strings.Movement.INVENTORY);
    }
}
