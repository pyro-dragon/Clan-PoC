using UnityEngine;
using System.Collections;

public class Footprint : MonoBehaviour 
{
	//public bool colliding;
	public int collidedObjects;

	// Use this for initialization
	void Start () 
	{
		//colliding = false;
		collidedObjects = -1;	// Take into account terrain collision
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		//colliding = true;
		Debug.Log("Trigger Enter");
		collidedObjects++;
	}

	void OnTriggerExit(Collider other)
	{
		//colliding = false;
		Debug.Log("Trigger Exit");
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
