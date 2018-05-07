using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : Button3D, IButton3D {
	[SerializeField]
	private string scenenName;
	/// <summary>
	/// This is an Interface function. This Activates the action of this button. This action loads a new scene.
	/// </summary>
	public override void Activate()
	{
		SceneManager.LoadScene(scenenName);
	}
}
