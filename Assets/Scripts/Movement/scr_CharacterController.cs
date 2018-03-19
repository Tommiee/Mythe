using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_CharacterController : MonoBehaviour {

    private scr_InputManager inputManager;

    [SerializeField]
    private GameObject inv;
    private Inventory inventory;

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
        inventory = inv.GetComponent<Inventory>();
    }

    void Update()
    {
        Walk();
        PickUp(grabRange);
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

    public void PickUp(float range)
    {
        //Finds the camera, and it's forward facing vector.
        Camera cam = gameObject.GetComponentInChildren<Camera>();
        Vector3 fwd = cam.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, fwd, out hit, range))
        {
            if (inputManager.F())
            {
                Collectable collectable;
                if (collectable = hit.transform.gameObject.GetComponent<Collectable>())
                {
                    ObjectData obj = hit.transform.gameObject.GetComponent<Collectable>().obj;

                    inventory.CollectedItem(obj);
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
