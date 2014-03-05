using UnityEngine;
using System.Collections;

public class Footprint : MonoBehaviour
{
	public int collidedObjects;		// Number of objects the footprint is interacting with
	//public Ray[] corners;
	public GameObject undergroundFootprint;
	public bool tooSteep;

	// Use this for initialization
	IEnumerator Start () 
	{
		// These two bits used to ensure the trigger is set. 
		yield return new WaitForFixedUpdate();
		collider.isTrigger = true;

		//collidedObjects = -1;	// Take into account terrain collision
		collidedObjects = 0;

		//corners = new Ray[4];
		BoxCollider box = GetComponent("BoxCollider") as BoxCollider;
		//corners[0].origin = box.bounds.max;
		//corners[1].origin = box.bounds.min;

		//Debug.Log("Max bounds: " + box.bounds.max);
		//Debug.Log("Min bounds: " + box.bounds.min);

		// Set up the undergroundFootprint. This is used to determine if the terrain is too steep to see if we have an collision between this and terrain. 
		undergroundFootprint = GameObject.CreatePrimitive(PrimitiveType.Cube);
		undergroundFootprint.transform.localScale = collider.bounds.size;
		undergroundFootprint.transform.position = new Vector3(collider.bounds.center.x, collider.bounds.center.y - ((collider.bounds.extents.y * 2) + 1.5f), collider.bounds.center.z);
		undergroundFootprint.transform.parent = transform;
		undergroundFootprint.AddComponent("SteepnessChecker");
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
