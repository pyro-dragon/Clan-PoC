using UnityEngine;
using System.Collections;

// A tool for placing buidings in the world
public class BuilderTool : PointerTool
{
	public GameObject currentBuilding;	// The currently selected building to place
	public bool siteClear;				// If the proposed site of building contruction is clear or not

	private validFootprintColour;
	private invalidFootprintColour;
	
	// Constructor
	public BuilderTool()
	{
		name = "Builder Tool";
		siteClear = true;
		validFootprintColour = Color.green;
		validFootprintColour.a = 0.5f;
		invalidFootprintColour = Color.red;
		invalidFootprintColour.a = 0.5f;
		
		// Set the wood shack as the default start building
		currentBuilding = GameObject.Instantiate(Resources.Load("PoC Prefabs/LoggingShed")) as GameObject;

		Deactivate();
	}

	public override void Activate()
	{
		currentBuilding.renderer.material.color = validFootprintColour;
	}

	public override void Deactivate()
	{
		currentBuilding.renderer.material.color = Color.clear;
	}

	public override void Update(RaycastHit target, Vector3 terrainPoint, bool hitStatus)
	{
		// Move the footprint
		currentBuilding.transform.position = terrainPoint;

		// Check if the site is clear
		//currentBuilding.collider.

		// Check for a click
		if(Input.GetMouseButtonUp(0) && siteClear) // Left click
		{
			// Create a new building
			Quaternion rotation = Quaternion.AngleAxis(270, Vector3.right);
			GameObject testHouse = GameObject.Instantiate(Resources.Load("Thatched cottages/Thatched cottages"), terrainPoint, Quaternion.AngleAxis(270, Vector3.right)) as GameObject;
		}
		else if(Input.GetMouseButtonUp(1)) // Right click
		{
			// Switch back to select tool
		}
	}

	// Function to switch the currently selected building and set up its shader and collider
	public void SelectNewBuilding(GameObject building)
	{
		// Set the current building
		currentBuilding = building;

		// Set the shader
		currentBuilding.renderer.material.color = validFootprintColour;
		currentBuilding.renderer.material.shader = Shader.Find("Custom/Footprint");

		// Set the collider
		currentBuilding.AddComponent("BoxCollider");
	}
}
