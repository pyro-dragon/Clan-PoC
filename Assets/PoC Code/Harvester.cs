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
	
	public GameObject targetResource;	// The currently targeted resource point
	public GameObject targetDepot;		// The currently used resource depot. 
	
	public Unit unitComponent;	// The unit component
	
	// Use this for initialization
	void Start () {
		unitComponent = this.gameObject.GetComponent("Unit");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// Function to initalise the harvesting cycle
	public void StartHarvesting()
	{
		// Set the pathing off. 
		unitComponent.SetNewTarget(targetResource.transform.position);
	}
}
