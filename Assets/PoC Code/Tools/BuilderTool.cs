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
		
	}
		
	// A unit has been clicked
	public override void UnitClicked(Unit unit, bool rightClick)
	{
		
	}
		
	// The terrain has been clicked
	public override void TerrainClicked(Vector3 position, bool rightClick)
	{
		// Terrain has been clicked. Place the building
		GameObject testHouse = GameObject.Instantiate(Resources.Load("Thatched cottages/Thatched cottages"), position, Quaternion.identity) as GameObject;
		
		//testHouse.transform.position = position;
	}
}
