using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(PlayerEngine))]
[RequireComponent(typeof(FirstPerson))]
public class PlayerController : MonoBehaviour
{
    private PlayerEngine playerEngine;
    private FirstPerson firstPerson;
    private SwitchController switchController;
    private InputManager inputManager;

    [SerializeField]
    private GameObject inventory;
    [SerializeField]
    private float grabRange = .1f;
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float camRotLimit = 85f;
    [SerializeField]
    private float sensitivity = 1;

    void Start()
    {
        this.GetComponentInChildren<Camera>().enabled = true;

        inputManager = GetComponent<InputManager>();
        playerEngine = GetComponent<PlayerEngine>();
        firstPerson = GetComponent<FirstPerson>();
        switchController = GetComponent<SwitchController>();
    }

    void Update()
    {
        Vector3 movHorizontal = this.transform.right * inputManager.XMov();
        Vector3 movVertical = this.transform.forward * inputManager.ZMov();
        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;

        Vector3 rotation = new Vector3(0f, inputManager.YRot(), 0f) * sensitivity;
        float cameraRotationX = inputManager.XRot() * sensitivity;

        firstPerson.Movement(speed, velocity);
        firstPerson.Rotation(rotation, cameraRotationX, camRotLimit);

        playerEngine.CollectItem(grabRange, inputManager.FPress());

        switchController.SwitchControl(inventory, this.gameObject, inputManager.TabPress());
    }
}
