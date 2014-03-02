using UnityEngine;
using System.Collections;

public class Harvester : MonoBehaviour {
	
	// Harvester cycle: 
	// 1. Go to resource deposit
	// 2. Check if resource is still available
	// 	2a. If yes, collect resource packet then go to 3. 
	// 	2b. If no, scan for nearby resources then go to 1. 
	// 3. Is harvester full?
	// 	3a. If yes, go to 4.
	// 	3b. If no, got to 2. 
	// 4. Return to depot. 
	// 5. Check if we can deposit
	// 	5a. If yes, deposit resource then go to 6. 
	// 	5b. If no, search for another depot then go to 4. 
	// 6. Is harvester empty?
	//	6a. If yes, go to 1. 
	// 	6b. If no, go to 5. 
	
	public ResourceDeposit targetResource;	// The currently targeted resource point
	public ResourceDepot targetDepot;		// The currently used resource depot. 
	GameManager gameManager;
	
	int resourceStore;
	string resourceType;
	
	public Unit unitComponent;	// The unit component
	public bool harvesting;		// Are we currently harvesting?
	
	// Use this for initialization
	void Start () {
		unitComponent = this.gameObject.GetComponent("Unit") as Unit;
		
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
			Debug.Log("Nav Target not null");
			
			if(navTarget.GetComponent("ResourceDeposit"))
			{
				// Take resources from the resource deposit
				resourceStore = targetResource.TakeResource(10);
				
				// Check if we can still use the current depot (not null and not full)
				if(targetDepot == null || targetDepot.AtCapacity())
				{
					Debug.Log("Target depot is null or full, searching for a new one... ");
					
					// Find a new depot
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
					targetDepot = closestDepot;
				}
				
				// Head back to the depot
				unitComponent.SetNavTarget(targetDepot.gameObject);
				
				//Debug.Log("Pathing back to depot");
			}
			else if(navTarget.GetComponent("ResourceDepot"))
			{
				// Drop off the load
				resourceStore = ((ResourceDepot)targetDepot.GetComponent("ResourceDepot")).DropOff(resourceStore);
				
				// Head back to the resource 
				unitComponent.SetNavTarget(targetResource.gameObject);
				
				//Debug.Log("Pathing back to resource");
			}
		}
	}
	
	void TargetSet(GameObject targetObject)
	{
		if(targetObject.GetComponent("ResourceDeposit"))
		{
			targetResource = targetObject.GetComponent("ResourceDeposit") as ResourceDeposit;
		}
		else if(targetObject.GetComponent("ResourceDepot"))
		{
			targetDepot = targetObject.GetComponent("ResourceDepot") as ResourceDepot;
		}
	}
}
