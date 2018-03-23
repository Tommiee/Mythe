using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingTheItem : MonoBehaviour {

	/// <summary>
	/// A script with sort function to find lightobjects in the Inventory
	/// </summary>
	[SerializeField]
	SearchTroughIventory searchTroughIventory;

	/// <summary>
	/// A Temporary Inventory for testing.
	/// </summary>
	[SerializeField]
	private List<GameObject> TempIventory;

	/// <summary>
	/// A slote for a lightobject that the player holds.
	/// </summary>
	private GameObject lightobject = null;

	/// <summary>
	/// Sets the lightobject slot to a new one.
	/// </summary>
	/// <param name="newHoldingItem"></param>
	private void SetHoldingItem(GameObject newHoldingItem)
	{
		if (lightobject != null)
		{
			Destroy(lightobject);
		}
		lightobject = newHoldingItem;
	}

	
	/// <summary>
	/// Sorts trough a list of lightobjects to get the one with the better range. 
	/// </summary>
	/// <param name="inventory"></param>
	private void FindLightobjectWithHigherRange(List<GameObject> inventory)
	{
		List<GameObject> proccesedInventory = SearchTroughIventory.SortListForObjectWithTag(inventory,"lightitem");
		if (proccesedInventory.Count > 1)
		{
			for (int i = 0; i < proccesedInventory.Count-1; i++)
			{	
				if (proccesedInventory[i].GetComponent<Light>().range > proccesedInventory[i+1].GetComponent<Light>().range)
				{
					SetHoldingItem(proccesedInventory[i+1]);
				}	else {
					SetHoldingItem(proccesedInventory[i]);
				}
			}
		}	else if (proccesedInventory.Count > 0) {
			SetHoldingItem(proccesedInventory[0]);
		}
	}

	private void Start()
	{
		FindLightobjectWithHigherRange(TempIventory);
		lightobject.SetActive(true);
	}
}
