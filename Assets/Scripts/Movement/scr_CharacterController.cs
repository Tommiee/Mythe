﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(InputManager))]
public class scr_CharacterController : MonoBehaviour
{
    private InputManager inputManager;

    [SerializeField]
    private GameObject inv;
    private Inventory inventory;

    [SerializeField]
    private Camera playerCam;
    [SerializeField]
    private Camera inventoryCam;

    private Rigidbody rb;
    [SerializeField]
    private float grabRange = 20f;

    [SerializeField]
    private float speed = 5;

    private bool movementLock;

    void Start()
    {
        //Find and add required scripts, if you've forgotten/dont want to add them in the editor.
        //Not completely necessary, but what the hell, i'm both lazy and forgetful.
        if (!(inputManager = this.GetComponent<InputManager>()))
        {
            inputManager = this.gameObject.AddComponent<InputManager>();
        }
        inventory = inv.GetComponent<Inventory>();
        rb = GetComponent<Rigidbody>();

        inventoryCam.enabled = false;
        playerCam.enabled = true;
    }

    void Update()
    {
        Walk();
        Inventory();
        PickUp(grabRange);
    }

    void Walk()
    {
        Vector3 movHorizontal = this.transform.right * inputManager.XMov();
        Vector3 movVertical = this.transform.forward * inputManager.ZMov();
        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;
        bool moving = inputManager.ZMov() != 0 || inputManager.XMov() != 0;

        if (velocity != Vector3.zero)
        {
            rb.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
        }
        if (moving) { speed += 0.2f; }
        else if (!moving)
        {
            speed = Mathf.Lerp(speed, 0f, 20 * Time.deltaTime);
        }
        speed = Mathf.Clamp(speed, -5, 5);
    }

    //These two are required for freezing the movement when opening the inventory.
    //I know it looks odd, but we need these.
    public void Inventory()
    {
        if(inputManager.Inventory() != 0)
        {
            inventoryCam.enabled = !inventoryCam.enabled;
            playerCam.enabled = !playerCam.enabled;
        }
    }

    public void PickUp(float range)
    {
        //Finds the camera, and it's forward facing vector.
        Camera cam = gameObject.GetComponentInChildren<Camera>();
        Vector3 fwd = cam.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, fwd, out hit, range))
        {
            if (inputManager.Interact() != 0)
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
