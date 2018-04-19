using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingTheItem : MonoBehaviour {

	/// <summary>
	/// A id for finding lightobjects in the Inventory
	/// </summary>
	[SerializeField]
	private int lightObjectsId;

	/// <summary>
	/// A script with sort function to find lightobjects in the Inventory
	/// </summary>
	SearchTroughInventory searchTroughIventory;

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
	/// The position here the lightobject should be.
	/// </summary>
	[SerializeField]
	private Vector3 lightobjectposition;

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
		lightobject = GameObject.Instantiate(newHoldingItem);
		lightobject.transform.SetParent(gameObject.transform);
		lightobject.transform.position = gameObject.transform.position + lightobjectposition;
	}

	
	/// <summary>
	/// Sorts trough a list of lightobjects to get the one with the better range. 
	/// </summary>
	/// <param name="inventory"></param>
	private void FindLightobjectWithHigherRange(List<GameObject> inventory)
	{
		List<GameObject> proccesedInventory = SearchTroughInventory.SortListForObjectWithTag(inventory,lightObjectsId);
		if (proccesedInventory.Count > 1)
		{
			for (int i = 0; i < proccesedInventory.Count-1; i++)
			{	
				if (proccesedInventory[i].GetComponent<Light>().range > proccesedInventory[i+1].GetComponent<Light>().range) {
					print(proccesedInventory[i]);
					SetHoldingItem(proccesedInventory[i]);
				}	else {
					SetHoldingItem(proccesedInventory[i+1]);
				}
			}
		}	else if (proccesedInventory.Count > 0) {
			SetHoldingItem(proccesedInventory[0]);
		}
	}

	private void Start()
	{
		FindLightobjectWithHigherRange(TempIventory);
		//Alightobject.SetActive(true);
	}
}
