using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_CharacterController : MonoBehaviour {
    private scr_InputManager inputManager;
    private scr_GrabObject grabManager;

    [SerializeField]
    private float grabRange = 20f;
    [SerializeField]
    private float inputSpeed = 5;
    [SerializeField]
    private float sprintMultiplier = 2;
    private float movementSpeed;
    private bool movementLock;

    void Start()
    {
        //Find and add required scripts, if you've forgotten/dont want to add them in the editor.
        //Not completely necessary, but what the hell, i'm both lazy and forgetful.
        if (!(inputManager = this.GetComponent<scr_InputManager>()))
        {
            inputManager = this.gameObject.AddComponent<scr_InputManager>();
        }
        if (!(grabManager = this.GetComponent<scr_GrabObject>()))
        {
            grabManager = this.gameObject.AddComponent<scr_GrabObject>();
        }
    }

    void Update()
    {
        Walk();
        Grab();
    }

    void Grab()
    {
        //It grabs stuff.
        if (inputManager.F())
        {
            GameObject grabbed = grabManager.PickUp(grabRange);
            Debug.Log(grabbed);
        }
    }

    void Walk()
    {
        if (!movementLock)
        {
            //This bit moves the character.
            Vector3 moveVector = new Vector3();
            movementSpeed = inputSpeed;

            if (inputManager.Shift())
            {
                movementSpeed = inputSpeed * sprintMultiplier;
            }
            if (inputManager.Up())
            {
                moveVector += this.transform.forward;
            }
            if (inputManager.Down())
            {
                moveVector -= this.transform.forward;
            }
            if (inputManager.Right())
            {
                moveVector += this.transform.right;
            }
            if (inputManager.Left())
            {
                moveVector -= this.transform.right;
            }
            moveVector.Normalize();
            this.transform.position += (moveVector * Time.deltaTime * movementSpeed);
        }
    }

    //These two are required for freezing the movement when opening the inventory.
    //I know it looks odd, but we need these.
    public void Freeze()
    {
        movementLock = true;
    }

    public void Unfreeze()
    {
        movementLock = false;
    }
}
