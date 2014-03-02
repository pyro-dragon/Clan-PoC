using UnityEngine;
using System.Collections;

public class ResourceDeposit : MonoBehaviour 
{
	public string resourceType;
	public int resourceRemaining;
	GameManager gameManager;
	
	// Use this for initialization
	void Start() 
	{
		gameManager = (GameManager)GameObject.Find("GameManager").GetComponent("GameManager");
	}
	
	// Update is called once per frame
	void Update() 
	{
		// Check if we still have any resources left
		if(resourceRemaining <= 0)
		{
			Debug.Log("Removing resource");
			Destroy(this.gameObject);
		}
	}
	
	//public void OnMouseOver()
	//{
	//	// Check for are right-click
	//	if(Input.GetMouseButtonUp(1))
	//	{
	//		Debug.Log("Resource clicked");
	//		
	//		// Transmit the location
	//		gameManager.GetUserInterface().GetCurrentTool().Click(this.gameObject, this.transform.position, true);
	//	}
	//}
	
	// A request to take some resources has been made
	public int TakeResource(int requestAmount)
	{
		int returnAmount;
		
		// Check if we can fully fulfil the request. 
		if(resourceRemaining < requestAmount)
		{
			// We can't, return what remains, zero what remains. 
			returnAmount = resourceRemaining; 
			resourceRemaining = 0;
		}
		else
		{
			// We can, return the amount requested and reduce the amount stored
			returnAmount = requestAmount;
			resourceRemaining -= requestAmount;
		}
		
		return returnAmount;
	}
}
