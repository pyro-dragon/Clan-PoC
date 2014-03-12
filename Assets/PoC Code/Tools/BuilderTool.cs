using UnityEngine;
using System.Collections;

// A tool for placing buidings in the world
public class BuilderTool : PointerTool
{
	public GameObject currentBuilding;	// The currently selected building to place
	public bool siteClear;				// If the proposed site of building contruction is clear or not
	private Color validFootprintColour;
	private Color invalidFootprintColour;
	public float lastXPos;				// Used for rotating buildings

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
		// Set the shed as the default start building (Replace this with something more suitable when this is a full working version)
		var gm = GameObject.Instantiate(Resources.Load("PoC Prefabs/Shack")) as GameObject;
		//var building = gm.GetComponent<Building>();
		//if (building == null)
		//{
		//	Debug.LogError("prefab must have a building script attached!");
		//}

		// Select a new building to place
		SelectNewBuilding(gm);

		lastXPos = 0.0f;
	}

	public override void Deactivate()
	{
		GameObject.Destroy(currentBuilding);
	}

	public override void Update(RaycastHit target, Vector3 terrainPoint, bool hitStatus)
	{
		if (currentBuilding == null)
			return;

		// Chech for rotation mode
		if(Input.GetKey(KeyCode.LeftShift))
		{
			// Left shift is down, lets rotate
			currentBuilding.transform.Rotate(Vector3.up * (Input.mousePosition.x - lastXPos));
			Debug.Log("rotating");
		}
		else
		{
			// Left shift isn't down, just move the footprint
			currentBuilding.transform.position = terrainPoint;
		}

		// Check if the site is clear
		//siteClear = currentBuilding.CheckSite();
		siteClear = (currentBuilding.GetComponent("Footprint") as Footprint).CheckValidSite();

		// Check if we can build here
		/*if (!siteClear || currentBuilding.mode == Building.Mode.INVALID_FOOTPRINT)
		{
			// Site not clear or the terrain is too steep
			currentBuilding.SetValidFootPrint();
		}
		else if(siteClear && currentBuilding.mode == Building.Mode.VALID_FOOTPRINT)
		{
			// Site clear and terrain is steep enough
			currentBuilding.SetInValidFootPrint();
		}*/

		if(siteClear)
		{
			for (var i = 0; i < currentBuilding.renderer.materials.Length; i++) {
				currentBuilding.renderer.materials[i].color = validFootprintColour;
			}
			//currentBuilding.renderer.material.color = validFootprintColour;
		}
			
		else
		{
			for (var i = 0; i < currentBuilding.renderer.materials.Length; i++) {
				currentBuilding.renderer.materials[i].color = invalidFootprintColour;
			}
			//currentBuilding.renderer.material.color = invalidFootprintColour;
		}

		// Check for a click
		if (Input.GetMouseButtonUp(0) && siteClear)	// Left click
		{
			// Create a new building
			GameObject testHouse = GameObject.Instantiate(Resources.Load("PoC Prefabs/Shack"), terrainPoint, currentBuilding.transform.localRotation) as GameObject;

			// Add to layer
			currentBuilding.layer = LayerMask.NameToLayer("Obstacles");

			// Update the node graph
			AstarPath.active.UpdateGraphs(testHouse.collider.bounds);
		}
		else if (Input.GetMouseButtonUp(1))
		{ // Right click
			// Switch back to select tool
		}

		lastXPos = Input.mousePosition.x;
	}
	
	// Function to switch the currently selected building and set up its shader and collider
	public void SelectNewBuilding(GameObject building)
	{
		// Set the current building
		currentBuilding = building;

		currentBuilding.name = "Footprint";

		// Set the collider
		GameObject.Destroy(currentBuilding.collider);
		currentBuilding.AddComponent("BoxCollider");
		currentBuilding.AddComponent("Rigidbody");
		currentBuilding.rigidbody.isKinematic = true;

		currentBuilding.AddComponent("Footprint");

		// Set up layer and ignore units
		currentBuilding.layer = LayerMask.NameToLayer("Footprint");
		Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Footprint"), LayerMask.NameToLayer("Units"));
		Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Footprint"), LayerMask.NameToLayer("Ground"));

		//currentBuilding.SetValidFootPrint();

	}
}
