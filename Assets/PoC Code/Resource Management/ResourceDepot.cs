using UnityEngine;
using System.Collections;

public class ResourceDepot : MonoBehaviour {
	
	public int capacity;
	int storedResource;
	GameManager gameManager;
	
	// Use this for initialization
	void Start () {
		gameManager = (GameManager)GameObject.Find("GameManager").GetComponent("GameManager");
		storedResource = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnMouseOver()
	{
		// Check for are right-click
		if(Input.GetMouseButtonUp(1))
		{
			// Transmit the location
			gameManager.GetUserInterface().GetCurrentTool().Click(this.gameObject, this.transform.position, true);
		}
	}
	
	// Receive resources and put them in the inventory, reterning any that are abouve the capacity. 
	public int DropOff(int resourceAmount)
	{
		// Add the resources to the stock pile
		storedResource += resourceAmount;
		
		// Check if we are over capacity
		if(storedResource > capacity)
		{
			// Reject excess resources
			int excess = capacity - storedResource;
			storedResource = capacity; 
			return excess;
		}
		
		return 0;
	}
	
	// Check if we are at capacity
	public bool AtCapacity()
	{
		if(storedResource < capacity)
			return false;
		else
			return true;
	}
}
