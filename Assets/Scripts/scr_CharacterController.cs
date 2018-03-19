using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_CharacterController : MonoBehaviour {

    private scr_InputManager inputManager;

    [SerializeField]
    private Inventory inventory;

    [SerializeField]
    private float inputSpeed = 5;

    [SerializeField]
    private float sprintMultiplier = 2;
    private float movementSpeed;

    void Start()
    {
        if (!(inputManager = this.GetComponent<scr_InputManager>()))
        {
            inputManager = this.gameObject.AddComponent<scr_InputManager>();
        }
    }

    void Update()
    {
        Walking();
    }

    void Walking()
    {
        Vector3 moveVector = new Vector3();
        movementSpeed = inputSpeed;

        if (inputManager.Shift()) {
            movementSpeed = inputSpeed * sprintMultiplier;
        }
        if (inputManager.Up()) {
            moveVector += this.transform.forward;
        }
        if (inputManager.Down()) {
            moveVector -= this.transform.forward;
        }
        if (inputManager.Right()) {
            moveVector += this.transform.right;
        }
        if (inputManager.Left()){
            moveVector -= this.transform.right;
        }
        moveVector.Normalize();
        this.transform.position += (moveVector * Time.deltaTime * movementSpeed);
    }

    void PickUp()
    {
        Camera cam = gameObject.GetComponentInChildren<Camera>();
        Vector3 fwd = cam.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, fwd, out hit, 100f))
        {
            if(inputManager.F())
            {
                inventory.CollectedItem(hit.GameObjec)
            }
        }
    }
}
