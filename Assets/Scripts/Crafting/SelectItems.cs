using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItems : MonoBehaviour
{
    [SerializeField]
    private List<CraftableItem> allCraftingRecipes = new List<CraftableItem>();
    [SerializeField]
    private List<ObjectData> crafting = new List<ObjectData>();

    private InputManager inputManager;

    void Start()
    {
        this.gameObject.GetComponent<InputManager>();
    }

    void Update()
    {
        SelectItem();
    }

    void SelectItem()
    {
        Camera cam = gameObject.GetComponentInChildren<Camera>();
        Vector3 fwd = cam.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, fwd, out hit, 4f))
        {
            if (inputManager.FPress())
            {
                Collectable collectable;
                if (collectable = hit.transform.gameObject.GetComponent<Collectable>())
                {
                    AddCraftInventory(hit.transform.gameObject);
                }
            }
        }
    }

    void AddCraftInventory(GameObject item)
    {
        crafting.Add(item.GetComponent<Collectable>().obj);
    }

    bool CheckRecipe(int recipe)
    {
        for (int i = 0; i < allCraftingRecipes[recipe].requiredIds.Count; i++)
        {
            for (int g = 0; g < crafting.Count; g++)
            {
                if (allCraftingRecipes[recipe].requiredIds[i] == crafting[g].id)
                {
                    return true;
                }
            }
        }
        return false;
    }
}