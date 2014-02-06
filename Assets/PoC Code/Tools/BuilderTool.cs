using UnityEngine;
using System.Collections;

// A tool for placing buidings in the world
public class BuilderTool : PointerTool
{
	public GameObject currentBuilding;
	
	// Constructor
	public BuilderTool()
	{
		name = "Builder Tool";
		
		// Set the wood shack as the default start building
		currentBuilding = GameObject.Instantiate(Resources.Load("Thatched cottages/Thatched cottages")) as GameObject;
	}
		
	// A general click command
	public override void Click(GameObject gameObject, Vector3 position, bool rightClick)
	{
		// Check for left-click
		if(!rightClick)
		{
			GameObject testHouse = GameObject.Instantiate(Resources.Load("Thatched cottages/Thatched cottages"), position, Quaternion.identity) as GameObject;
		}
	}
	
	public override void MouseOver(GameObject gameObject, Vector3 position)
	{
		
	}
	
	public override void MouseExit(GameObject gameObject, Vector3 position)
	{
		
	}
}
