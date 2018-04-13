using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchTroughInventory : MonoBehaviour {
	/// <summary>
	/// Sorts trough a list of gameobjects with given tag. Then sets it in a list and returns it.
	/// This had to change to be easyly implemented to Robins code.
	/// </summary>
	/// <param name="inventory"></param>
	/// <param name="tag"></param>
	/// <returns></returns>
	public static List<GameObject> SortListForObjectWithTag(List<GameObject> inventory,int id)
	{
		List<GameObject> lightItems = new List<GameObject>();
		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory[i].GetComponent<ObjectData>().id == id)
			{
				lightItems.Add(inventory[i]);
			}
		}
		return lightItems;
	}
}
