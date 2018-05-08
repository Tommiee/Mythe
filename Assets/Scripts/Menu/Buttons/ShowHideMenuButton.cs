using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideMenuButton : Button3D, IButton3D
{
	[SerializeField]
	private GameObject newMenu;
	[SerializeField]
	private GameObject parent;
	// Use this for initialization
	public override void Activate()
	{
		newMenu.gameObject.SetActive(true);
		parent.gameObject.SetActive(false);
	}
}
