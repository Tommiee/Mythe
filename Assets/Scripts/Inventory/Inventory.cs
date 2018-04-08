using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<int> inventory = new List<int>();
    private List<GameObject> inventoryUseable = new List<GameObject>();
    [SerializeField]
    private List<GameObject> inventoryModels = new List<GameObject>();

    [SerializeField]
    private GameObject craftButton;

    [SerializeField]
    private List<CraftableItem> allCraftingRecipes = new List<CraftableItem>();
    [SerializeField]
    private List<GameObject> crafting = new List<GameObject>();

    [SerializeField]
    private GameObject player;

    private int differentItems = 16;
    private int craftableRecipe;

    void Start()
    {
        this.GetComponentInChildren<Camera>().enabled = false;

        FillInventory(differentItems);
    }

    void FillInventory(int amount)
    {
        for (var i = 0; i < amount; i++)
        {
            inventory.Add(0);
        }
    }

    public void DisplayItem(ObjectData item)
    {
        inventoryModels[item.id].SetActive(true);
    }

    public void AddToInventory(ObjectData item)
    {
        inventory[item.id] += 1;
    }

    public void RemoveFromInventory(ObjectData item)
    {
        inventory[item.id] -= 1;
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
        return (found == allCraftingRecipes[recipe].requiredIds.Count && !(allCraftingRecipes[recipe].requiredIds.Count < crafting.Count)) ? true : false;
    }

    void CheckAllRecipes()
    {
        int count = 0;
        for (int i = 0; i < allCraftingRecipes.Count; i++)
        {
            if (CheckRecipe(i))
            {
                print(i + "goeie");
                craftableRecipe = i;
            }
            else if(!CheckRecipe(i))
            {
                count++;
            }
        }
        if(count >= allCraftingRecipes.Count)
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
                Craft(hit.transform.gameObject);
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
                AddToInventory(collectable.obj);
                RemoveCraftInventory(gameObject);
                collectable.inCraft = false;
            }
            else if (!collectable.inCraft)
            {
                AddCraftInventory(gameObject);
                RemoveFromInventory(collectable.obj);
                collectable.inCraft = true;
            }
            CheckAllRecipes();
            CraftButton();
        }
    }
    void Craft(GameObject gameObject)
    {
        if(gameObject.name == "CraftButton")
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
