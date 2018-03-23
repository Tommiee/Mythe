using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchTroughIventory : MonoBehaviour {
	/// <summary>
	/// Sorts trough a list of gameobjects with given tag. Then sets it in a list and returns it.
	/// </summary>
	/// <param name="inventory"></param>
	/// <param name="tag"></param>
	/// <returns></returns>
	public static List<GameObject> SortListForObjectWithTag(List<GameObject> inventory,string tag)
	{
		List<GameObject> lightItems = new List<GameObject>();
		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory[i].tag == "lightItem")
			{
				lightItems.Add(inventory[i]);
			}
		}
		return lightItems;
	}
}
