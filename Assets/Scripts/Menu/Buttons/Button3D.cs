using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3D : MonoBehaviour , IButton3D {

	Animator animator;
	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	/// <summary>
	/// Does stuff on deselect
	/// </summary>
	public void OnDeselected()
	{
		animator.SetBool("selected",false);
	}

	/// <summary>
	/// Does stuff on select
	/// </summary>
	public void OnSelected()
	{
		animator.SetBool("selected", true);
	}


	/// <summary>
	/// A Template Activation fuction for the IButton, needed for an IButton3D
	/// </summary>
	public virtual void Activate()
	{
		//Does nothing
	}
}
