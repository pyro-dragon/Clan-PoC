﻿using UnityEngine;
using System.Collections;

public class Footprint : MonoBehaviour
{
	public int collidedObjects;
	public Ray[] corners;

	// Use this for initialization
	IEnumerator Start () 
	{
		// These two bits used to ensure the trigger is set. 
		yield return new WaitForFixedUpdate();
		collider.isTrigger = true;

		collidedObjects = -1;	// Take into account terrain collision

		corners = new Ray[4];
		BoxCollider box = GetComponent("BoxCollider") as BoxCollider;
		corners[0].origin = box.bounds.max;
		corners[1].origin = box.bounds.min;

		Debug.Log("Max bounds: " + box.bounds.max);
		Debug.Log("Min bounds: " + box.bounds.min);
	}

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log("Trigger Enter");
		collidedObjects++;
	}

	void OnTriggerExit(Collider other)
	{
		//Debug.Log("Trigger Exit");
		collidedObjects--;
	}

	// Uses the numbe rof enter and exits to detemine if the object is currently colliding or not
	public bool Colliding()
	{
		if(collidedObjects > 0)
			return true;
		else
			return false;
	}
}
