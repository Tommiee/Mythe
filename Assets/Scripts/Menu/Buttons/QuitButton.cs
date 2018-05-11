using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : Button3D, IButton3D {

	/// <summary>
	/// This is an Interface function. This Activates the action of this button. This action quits the game.
	/// </summary>
	public override void Activate()
	{
		Application.Quit();
	}
}
