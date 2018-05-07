﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControles : MonoBehaviour {
	[SerializeField]
	private List<GameObject> buttons = new List<GameObject>();
	private GameObject selectedButton;
	private int index;

	// Start is called on initialization of object
	void Start () {
		selectedButton = buttons[index];
		selectedButton.GetComponent<IButton3D>().OnSelected();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			MoveOne(Directions.Up);
		}

		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			MoveOne(Directions.Down);
		}

		if (Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			Continue();
		}
	}

	public void MoveOne(Directions directions)
	{
		if (directions == Directions.Up)
		{
			if (index > 0)
			{
				index--;
			}
			
		}
		else
		{
			if (index < buttons.Count - 1)
			{
				index++;
			}
		}
		selectedButton.GetComponent<IButton3D>().OnDeselected();
		selectedButton = buttons[index];
		selectedButton.GetComponent<IButton3D>().OnSelected();
	}

	public void Continue()
	{
		
		selectedButton.GetComponent<IButton3D>().Activate();
	}
}
public enum Directions { Up, Down }