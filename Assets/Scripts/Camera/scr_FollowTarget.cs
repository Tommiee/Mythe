using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_FollowTarget : MonoBehaviour {

	/// <summary>
	/// This Script is used to follow a set target
	/// </summary>

	[SerializeField]
	private GameObject target;

	[SerializeField]
	private Vector3 offset;
	
	// Update is called once per frame
	private void Update () {
		this.transform.position = target.transform.position + offset;
	}

	// Sets the current target to a new target
	public void SetTarget(GameObject newtarget){
		target = newtarget;
	}

	// Gets the current target
	GameObject GetTarget(){
		return target;
	}
}
