using UnityEngine;

public class InputManager : MonoBehaviour
{
    bool prevInventory;
    bool currInventory;

    bool prevInteract;
    bool currInteract;

    bool prevMouse;
    bool currMouse;

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
    public float F()
    {
        return Input.GetAxis(Strings.Movement.INTERACT);
    }
    public float Tab()
    {
        return Input.GetAxis(Strings.Movement.INVENTORY);
    }
    public float MouseClick()
    {
        return Input.GetAxis(Strings.Movement.MOUSECLICK);
    }
    public bool FPress()
    {
        bool press;

        prevInteract = currInteract;
        currInteract = F() != 0;

        if (!prevInteract && currInteract)
        {
            press = true;
        }
        else
        {
            press = false;
        }

        return press;
    }
    public bool TabPress()
    {
        bool press;

        prevInventory = currInventory;
        currInventory = Tab() != 0;

        if (!prevInventory && currInventory)
        {
            press = true;
        }
        else
        {
            press = false;
        }

        return press;
    }
    public bool MouseClickPress()
    {
        bool press;

        prevMouse = currMouse;
        currMouse = MouseClick() != 0;

        if (!prevMouse && currMouse)
        {
            press = true;
        }
        else
        {
            press = false;
        }

        return press;
    }
}