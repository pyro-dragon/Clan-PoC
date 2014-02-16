using UnityEngine;
using System.Collections;

public class Harvester : MonoBehaviour {
	
	// Harvester cycle: 
	// 1. Go to resource deposit
	// 2. Check if resource is still available
	// 	  2a. If yes, collect resource packet then go to 3. 
	// 	  2b. If no, scan for nearby resources then go to 1. 
	// 3. Is harvester full?
	// 	  3a. If yes, go to 4.
	// 	  3b. If no, got to 2. 
	// 4. Return to depot. 
	// 5. Check if we can deposit
	// 	  5a. If yes, deposit resource then go to 6. 
	//    5b. If no, search for another depot then go to 4. 
	// 6. Is harvester empty?
	//	  6a. If yes, go to 1. 
	// 	  6b. If no, go to 5. 
	
	public ResourceDeposit targetResource;	// The currently targeted resource point
	public ResourceDepot targetDepot;		// The currently used resource depot. 
	GameManager gameManager;
	
	public int resourceStore;
	public string resourceType;
	
	public Unit unitComponent;	// The unit component
	public bool harvesting;		// Are we currently harvesting?	Obsolete now I think
	
	public Vector3 resourceTargetPosition;	// Used to track the location of the resource we are currently harvesting. It is used to find nearby resources should this one expire. 
	public float resourceGatherRange;		// The distance from the original resource to search
	
	// Use this for initialization
	void Start () {
		unitComponent = this.gameObject.GetComponent("Unit") as Unit;
		resourceGatherRange = 10.0f;
		
		// Add the deligates
		unitComponent.pathComplete += PathComplete;
		unitComponent.targetSet += TargetSet;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// Function to initalise the harvesting cycle
	public void StartHarvesting()
	{
		// Set the pathing off. 
		unitComponent.SetNavTarget(targetResource.gameObject);
	}
	
	// The harvesting deligate to give to the unit on path completion
	void PathComplete(GameObject navTarget)
	{
		if(navTarget!= null)
		{
			if(navTarget.GetComponent("ResourceDeposit"))
			{
				// Take resources from the resource deposit
				resourceStore = targetResource.TakeResource(10);
				
				// Check if we can still use the current depot (not null and not full)
				if(targetDepot == null || targetDepot.AtCapacity())
				{
					targetDepot = FindDepot();
					
					// If we didn't get a valid depot back then stop everything
					if(targetDepot == null)
						return;
				}
				
				// Head back to the depot
				unitComponent.SetNavTarget(targetDepot.gameObject);
				
				//Debug.Log("Pathing back to depot");
			}
			else if(navTarget.GetComponent("ResourceDepot"))
			{
				// Drop off the load
				resourceStore = ((ResourceDepot)targetDepot.GetComponent("ResourceDepot")).DropOff(resourceStore);
				
				// Check if we have any load left over (the depot is full)
				if(resourceStore > 0)
				{
					//Debug.Log("Got Excess load");
					// We need to go look for a new depot
					targetDepot = FindDepot();
					
					// If we didn't get a valid depot back then stop everything
					if(targetDepot == null)
						return;
					
					// Head back to the other depot
					unitComponent.SetNavTarget(targetDepot.gameObject);
				}
				else
				{
					// Check if the current resource is still there
					if(targetResource == null)
					{
						// It isn't look for a nearby resource to get instead
						targetResource = FindDeposit();
						
						// Check if we actully have a new resource
						if(targetResource == null)
							return;	// Stop everything, there is no resource
					}
					
					// Head back to the resource 
					unitComponent.SetNavTarget(targetResource.gameObject);
				}
			}
		}
	}
	
	// Deligate to determine what was selected as a target by the unit
	void TargetSet(GameObject targetObject)
	{
		if(targetObject.GetComponent("ResourceDeposit"))
		{
			targetResource = targetObject.GetComponent("ResourceDeposit") as ResourceDeposit;
			resourceTargetPosition = targetObject.transform.position;
		}
		else if(targetObject.GetComponent("ResourceDepot"))
		{
			targetDepot = targetObject.GetComponent("ResourceDepot") as ResourceDepot;
		}
	}
	
	// Find a new depot
	ResourceDepot FindDepot()
	{
		ResourceDepot[] depotList = GameObject.FindObjectsOfType(typeof(ResourceDepot)) as ResourceDepot[];
		ResourceDepot closestDepot = depotList[0];
		float closestDistance = Vector3.Distance(transform.position, closestDepot.transform.position);
		foreach(ResourceDepot depot in depotList)
		{
			// Check if the next depot is full and closer than the last depot
			if(!depot.AtCapacity() && (closestDistance > Vector3.Distance(transform.position, depot.transform.position)))
			{
				closestDepot = depot;
			}
		}
		
		// Assign the new depot
		
		// Check to see if the defaulted first depot in the list is not full if that happens to have been the only one available
		if(closestDepot.AtCapacity())
		{
			// Closest depot is full and there are no others. Stop everything. 
			//Debug.Log("Everything is terrible D:");
			return null;
		}
		else
		{
			return closestDepot;
		}
	}
	
	// Find new resources
	ResourceDeposit FindDeposit()
	{
		Debug.Log("Finding a new deposit");
		
		// Place a collision sphere to get a list of nearby resource deposits (by collider)
		Collider[] hitColliders = Physics.OverlapSphere(resourceTargetPosition, resourceGatherRange);
		ResourceDeposit closestDeposit = null;	// The closest deposit to the last location
		float closestDistance = 0.0f;
		
		// Find the closest resource
		foreach(Collider hitCollider in hitColliders)
		{
			Debug.Log("Getting a new collider");
			ResourceDeposit tempResource;
			
			// Check if the collider is a resource deposit
			if(tempResource = hitCollider.GetComponent("ResourceDeposit") as ResourceDeposit)
			{
				Debug.Log("The collider is a resource deposit");
				// Set the resource if we don't have one yet
				if(closestDeposit == null)
				{
					Debug.Log("Setting the first resource");
					closestDeposit = tempResource;
					closestDistance = Vector3.Distance(transform.position, tempResource.transform.position);
				}
				else
				{
					Debug.Log("Comparing distances");
					// Ok, the closest resource is defined, check the distance
					if(closestDistance > Vector3.Distance(transform.position, tempResource.transform.position))
					{
						Debug.Log("Setting new closest resource");
						closestDeposit = tempResource;
					}
				}
			}
		}
		
		// Return the new deposit (or null if one is not found)
		return closestDeposit;
	}
}
