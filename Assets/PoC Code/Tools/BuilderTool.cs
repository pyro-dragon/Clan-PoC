using UnityEngine;
using System.Collections;

// A tool for placing buidings in the world
public class BuilderTool : PointerTool
{
	public Building currentBuilding;
	// The currently selected building to place
	public bool siteClear;
	// If the proposed site of building contruction is clear or not
	private Color validFootprintColour;
	private Color invalidFootprintColour;
	// Constructor
	public BuilderTool()
	{
		Debug.Log("Builder tool");
		name = "Builder Tool";
		siteClear = false;
		validFootprintColour = Color.green;
		validFootprintColour.a = 0.5f;
		invalidFootprintColour = Color.red;
		invalidFootprintColour.a = 0.5f;

		// Deactivate the tool
		Deactivate();
	}

	public override void Activate()
	{
		// Set the wood shack as the default start building (Replace this with something more suitable when this is a full working version)
		var gm = GameObject.Instantiate(Resources.Load("PoC Prefabs/LoggingShed")) as GameObject;
		var building = gm.GetComponent<Building>();
		if (building == null)
		{
			Debug.LogError("prefab must have a building script attached!");
		}
		SelectNewBuilding(building);
	}

	public override void Deactivate()
	{
		GameObject.Destroy(currentBuilding);
		//currentBuilding.renderer.material.color = Color.clear;
	}

	public override void Update(RaycastHit target, Vector3 terrainPoint, bool hitStatus)
	{
		if (currentBuilding == null)
			return;

		// Move the footprint
		currentBuilding.transform.position = terrainPoint;

		siteClear = currentBuilding.CheckSite();
		// Check if the site is clear
		if (siteClear && currentBuilding.mode == Building.Mode.INVALID_FOOTPRINT)
		{
			currentBuilding.SetValidFootPrint();
		}
		else if(!siteClear && currentBuilding.mode == Building.Mode.VALID_FOOTPRINT)
		{
			currentBuilding.SetInValidFootPrint();
		}


		// Check for a click
		if (Input.GetMouseButtonUp(0) && siteClear)
		{ // Left click
			// Create a new building
			Quaternion rotation = Quaternion.AngleAxis(270, Vector3.right);
			GameObject testHouse = GameObject.Instantiate(Resources.Load("PoC Prefabs/LoggingShed"), terrainPoint, Quaternion.AngleAxis(270, Vector3.right)) as GameObject;
		}
		else if (Input.GetMouseButtonUp(1))
		{ // Right click
			// Switch back to select tool
		}
	}



	// Function to switch the currently selected building and set up its shader and collider
	public void SelectNewBuilding(Building building)
	{
		// Set the current building
		currentBuilding = building;
		currentBuilding.SetValidFootPrint();

	}
}
