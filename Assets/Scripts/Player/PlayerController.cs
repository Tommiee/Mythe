using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FirstPerson))]
public class PlayerController : MonoBehaviour
{
    private FirstPerson firstPerson;
    private Pickup pickup;
    private InputManager inputManager;
    private Inventory inventory;

    [SerializeField]
    private GameObject inventoryGO;
    [SerializeField]
    private float grabRange = .1f;
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float camRotLimit = 85f;
    [SerializeField]
    private float sensitivity = 1;

    private enum PlayerState {PLAYER, INVENTORY, PAUSE};
    private PlayerState currentState;

    void Start()
    {
        this.GetComponentInChildren<Camera>().enabled = true;

        inputManager = GetComponent<InputManager>();
        firstPerson = GetComponent<FirstPerson>();
        pickup = GetComponent<Pickup>();
        inventory = inventoryGO.GetComponent<Inventory>();

        currentState = PlayerState.PLAYER;
    }

    void Update()
    {
        switch (currentState)
        {
            case PlayerState.PLAYER:

                Vector3 movHorizontal = this.transform.right * inputManager.XMov();
                Vector3 movVertical = this.transform.forward * inputManager.ZMov();
                Vector3 velocity = (movHorizontal + movVertical).normalized * speed;

                Vector3 rotation = new Vector3(0f, inputManager.YRot(), 0f) * sensitivity;
                float cameraRotationX = inputManager.XRot() * sensitivity;

                firstPerson.Movement(speed, velocity);
                firstPerson.Rotation(rotation, cameraRotationX, camRotLimit);
                pickup.CollectItem(grabRange, inputManager.FPress());

                SwitchController(inputManager.TabPress(), inventoryGO, gameObject, PlayerState.INVENTORY);

                break;
            case PlayerState.INVENTORY:

                inventory.Crafting(inputManager.FPress());
                SwitchController(inputManager.TabPress(), gameObject, inventoryGO, PlayerState.PLAYER);

                break;
            case PlayerState.PAUSE:

                break;
        }
    }

    void SwitchController(bool input, GameObject to, GameObject from, PlayerState state)
    {
        if (input)
        {
            to.GetComponentInChildren<Camera>().enabled = true;
            from.GetComponentInChildren<Camera>().enabled = false;
            currentState = state;
        }
    }
}
