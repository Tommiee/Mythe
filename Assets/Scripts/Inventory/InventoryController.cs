using System.Collections;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private Inventory inv;
    private InputManager inputManager;

    [SerializeField]
    private GameObject pl;
    private scr_CharacterController player;
    [SerializeField]
    private bool cooldown;

    void Start()
    {
        this.GetComponentInChildren<Camera>().enabled = false;
        this.enabled = false;

        player = pl.GetComponent<scr_CharacterController>();
        inv = this.GetComponent<Inventory>();
        inputManager = this.gameObject.AddComponent<InputManager>();
    }
    void Update()
    {
        Inventory();
    }
    void Inventory()
    {
        if (inputManager.Inventory() != 0 && !cooldown)
        {
            pl.GetComponentInChildren<Camera>().enabled = true;
            this.GetComponentInChildren<Camera>().enabled = false;
            player.enabled = true;
            player.StartCoroutine(InventoryCoolDown());
            this.enabled = false;
        }
    }
    public IEnumerator InventoryCoolDown()
    {
        cooldown = true;
        yield return new WaitForSeconds(1f);
        cooldown = false;
    }
}
