using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(InputManager))]
public class scr_CharacterController : MonoBehaviour
{
    private InputManager inputManager;

    [SerializeField]
    private GameObject inv;
    private Inventory inventory;
    private InventoryController invController;

    private Rigidbody rb;
    [SerializeField]
    private float grabRange = 20f;

    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private bool cooldown;

    void Start()
    {
        inputManager = GetComponent<InputManager>();
        inventory = inv.GetComponent<Inventory>();
        invController = inv.GetComponent<InventoryController>();
        rb = GetComponent<Rigidbody>();

        this.GetComponentInChildren<Camera>().enabled = true;
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
    void Inventory()
    {
        if (inputManager.Inventory() != 0 && !cooldown)
        {
            inv.GetComponentInChildren<Camera>().enabled = true;
            this.GetComponentInChildren<Camera>().enabled = false;
            invController.enabled = true;
            invController.StartCoroutine(InventoryCoolDown());
            this.enabled = false;
        }
    }

    void PickUp(float range)
    {
        //Finds the camera, and it's forward facing vector.
        Camera cam = gameObject.GetComponentInChildren<Camera>();
        Vector3 fwd = cam.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, fwd, out hit, range))
        {
            if (inputManager.Interact() != 0 && !cooldown)
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
    public IEnumerator InventoryCoolDown()
    {
        cooldown = true;
        yield return new WaitForSeconds(1f);
        cooldown = false;
    }
}
