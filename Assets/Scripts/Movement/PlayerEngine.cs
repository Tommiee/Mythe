using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(InputManager))]
public class PlayerEngine : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private GameObject canvas;
    private ShowObject showObject;

    [SerializeField]
    private GameObject inventory;
    private InventoryController inventoryController;

    float currentCamRotX = 0;

    void Start()
    {
        this.GetComponentInChildren<Camera>().enabled = true;
        this.enabled = true;

        rb = GetComponent<Rigidbody>();
        showObject = canvas.GetComponent<ShowObject>();
        inventoryController = inventory.GetComponent<InventoryController>();
    }

    public void PeformMovement(float speed, Vector3 velocity)
    {
        bool move = velocity != Vector3.zero;

        if (move)
        {
            rb.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
            speed += 0.2f;
        }
        else
        {
            speed = Mathf.Lerp(speed, 0f, 20 * Time.deltaTime);
        }
        speed = Mathf.Clamp(speed, -5, 5);
    }

    public void PerformRotation(Vector3 rotation, float cameraRotationX, float camRotLimit)
    {
        rb.MoveRotation(transform.rotation * Quaternion.Euler(rotation));
        if (this.GetComponentInChildren<Camera>() != null)
        {
            currentCamRotX -= cameraRotationX;
            currentCamRotX = Mathf.Clamp(currentCamRotX, -camRotLimit, camRotLimit);

            this.GetComponentInChildren<Camera>().transform.localEulerAngles = new Vector3(currentCamRotX, 0f, 0f);
        }
    }
    public void PefromSwitchController(GameObject to, GameObject from, bool when)
    {
        if (when)
        {
            to.GetComponentInChildren<Camera>().enabled = true;
            to.gameObject.SetActive(true);

            from.GetComponentInChildren<Camera>().enabled = false;
            from.gameObject.SetActive(false);
        }
    }

    public void PeformCollectItem(float range, bool when)
    {
        Camera cam = gameObject.GetComponentInChildren<Camera>();
        Vector3 fwd = cam.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, fwd, out hit, range))
        {
            if (when)
            {
                Collectable collectable;
                if (collectable = hit.transform.gameObject.GetComponent<Collectable>())
                {
                    ObjectData obj = hit.transform.gameObject.GetComponent<Collectable>().obj;

                    showObject.ShowCollectable(obj);
                    inventoryController.inventoryEngine.AddDataTo(obj, inventoryController.inventory);
                    inventoryController.inventoryEngine.DisplayItem(obj, inventoryController.inventoryModels);

                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
