using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerEngine))]
public class PlayerController : MonoBehaviour
{
    private PlayerEngine playerEngine;
    private InputManager inputManager;

    [SerializeField]
    private GameObject inventory;
    [SerializeField]
    private float grabRange = 2f;
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float camRotLimit = 85f;
    [SerializeField]
    private float sensitivity = 1;

    void Start()
    {
        inputManager = GetComponent<InputManager>();
        playerEngine = GetComponent<PlayerEngine>();
    }

    void Update()
    {
        Vector3 movHorizontal = this.transform.right * inputManager.XMov();
        Vector3 movVertical = this.transform.forward * inputManager.ZMov();
        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;

        Vector3 rotation = new Vector3(0f, inputManager.YRot(), 0f) * sensitivity;
        float cameraRotationX = inputManager.XRot() * sensitivity;

        playerEngine.PeformMovement(speed, velocity);
        playerEngine.PerformRotation(rotation, cameraRotationX, camRotLimit);
        playerEngine.PeformCollectItem(grabRange, inputManager.FPress());
        playerEngine.PefromSwitchController(inventory, this.gameObject, inputManager.TabPress());
    }
}
