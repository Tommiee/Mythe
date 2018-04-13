using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{
    private Inventory inventory;

    [SerializeField]
    private GameObject craftButton;

    [SerializeField]
    private List<CraftableItem> allCraftingRecipes = new List<CraftableItem>();
    [SerializeField]
    private List<GameObject> crafting = new List<GameObject>();

    private int craftableRecipe;

    void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    void AddCraftInventory(GameObject item)
    {
        crafting.Add(item);
    }

    void RemoveCraftInventory(GameObject item)
    {
        crafting.Remove(item);
    }

    bool CheckRecipe(int recipe)
    {
        int found = 0;
        for (int i = 0; i < allCraftingRecipes[recipe].requiredIds.Count; i++)
        {
            for (int g = 0; g < crafting.Count; g++)
            {
                if (allCraftingRecipes[recipe].requiredIds[i] == crafting[g].GetComponent<Collectable>().obj.id)
                {
                    found++;
                }
            }
        }
        return (found == allCraftingRecipes[recipe].requiredIds.Count && !(allCraftingRecipes[recipe].requiredIds.Count < crafting.Count));
    }

    void CheckAllRecipes()
    {
        int count = 0;
        for (int i = 0; i < allCraftingRecipes.Count; i++)
        {
            if (CheckRecipe(i))
            {
                craftableRecipe = i;
            }
            else if (!CheckRecipe(i))
            {
                count++;
            }
        }
        if (count >= allCraftingRecipes.Count)
        {
            craftableRecipe = 0;
        }
    }

    public void Crafting(bool input)
    {
        Camera cam = gameObject.GetComponentInChildren<Camera>();
        Ray fwd = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(fwd, out hit, 6f))
        {
            if (input)
            {
                ToggleCraftInventory(hit.transform.gameObject);
                CraftItem(hit.transform.gameObject);
            }
        }
    }

    public void ToggleCraftInventory(GameObject gameObject)
    {
        Collectable collectable;
        if (collectable = gameObject.GetComponent<Collectable>())
        {
            if (collectable.inCraft)
            {
                inventory.AddToInventory(collectable.obj);
                RemoveCraftInventory(gameObject);
                collectable.inCraft = false;
            }
            else if (!collectable.inCraft)
            {
                AddCraftInventory(gameObject);
                inventory.RemoveFromInventory(collectable.obj);
                collectable.inCraft = true;
            }
            CheckAllRecipes();
            CraftButton();
        }
    }
    void CraftItem(GameObject gameObject)
    {
        if (gameObject.name == "CraftButton")
        {
            Instantiate(allCraftingRecipes[craftableRecipe].model);
            for (int i = 0; i < crafting.Count; i++)
            {
                crafting[i].SetActive(false);
            }
            crafting.Clear();
            CheckAllRecipes();
            CraftButton();
        }
    }

    void CraftButton()
    {
        if (craftableRecipe > 0)
        {
            craftButton.SetActive(true);
        }
        else
        {
            craftButton.SetActive(false);
        }
    }
}
