using UnityEngine;
using System.Collections;

public class Footprint : MonoBehaviour
{
	public int collidedObjects;		// Number of objects the footprint is interacting with
	public Ray[] cornerRays;
	public GameObject[] samplePoints;
	public bool tooSteep;

	// Use this for initialization
	IEnumerator Start () 
	{
		// These two bits used to ensure the trigger is set. 
		yield return new WaitForFixedUpdate();
		collider.isTrigger = true;

		//collidedObjects = -1;	// Take into account terrain collision
		collidedObjects = 0;

		// Get the bottom corners of the bounding box
		Vector3[] corners = new Vector3[4];
		corners[0] = new Vector3(collider.bounds.center.x - collider.bounds.extents.x, collider.bounds.center.y - collider.bounds.extents.y, collider.bounds.center.z - collider.bounds.extents.z);

		cornerRays = new Ray[4];
		BoxCollider box = GetComponent("BoxCollider") as BoxCollider;
		cornerRays[0].origin = box.bounds.max;
		cornerRays[1].origin = box.bounds.min;

		//Debug.Log("Max bounds: " + box.bounds.max);
		//Debug.Log("Min bounds: " + box.bounds.min);
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
