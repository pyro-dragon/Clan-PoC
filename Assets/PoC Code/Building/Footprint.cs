using UnityEngine;
using System.Collections;

public class Footprint : MonoBehaviour 
{
	public int collidedObjects;

	// Use this for initialization
	IEnumerator Start () 
	{
		// These two bits used to ensure the trigger is set. 
		yield return new WaitForFixedUpdate();
		collider.isTrigger = true;

		collidedObjects = -1;	// Take into account terrain collision
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
