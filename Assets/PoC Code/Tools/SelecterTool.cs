using UnityEngine;
using System.Collections;

// The unit selection and command tool
public class SelecterTool : PointerTool
{
	Unit selectedUnit;		// Selected unit
	GameObject indicator;	// The indicator (used to show the selected unit)
	GameObject targetMarker;// An object to show the current pathfinding target
	
	// Constructor
	public SelecterTool()
	{
		name = "Selector Tool";
		selectedUnit = null;	// Set the selected unit to null
		
		// Intitalise the target prefab
		targetMarker = GameObject.Instantiate(Resources.Load("TargetPrefab")) as GameObject;
	}
	
	public override void SwitchTo()
	{
		
	}
	
	public override void SwitchFrom()
	{
		
	}
		
	// A general click function
	public override void Click(GameObject gameObject, Vector3 position, bool rightClick)
	{
		// Check if we have selected a unit
		if(gameObject.GetComponent("Unit"))
		{
			// Check the type of the click
			if(!rightClick)
			{
				// Remove current selection
				Deselect();
		
				// Set the selected object
				selectedUnit = gameObject.GetComponent("Unit") as Unit;
		
				// Create a new indicator
				indicator = GameObject.Instantiate(Resources.Load("IndicatorPrefab")) as GameObject;
		
				// Set the indicator as a member of the selected unit
				indicator.transform.position = selectedUnit.transform.position;
				indicator.transform.parent = selectedUnit.transform;
			}
		}
		
		// Otherwise check for a terrain click
		else if(gameObject.GetComponent("TerrainInteracter"))
		{
			// Check the type of click
			if(rightClick)
			{
				// Right-click, send the unit to the target location
				SetTarget(position);
			}
			else
			{
				// Left-click, deselect the current unit
				Deselect();
			}
		}
		
		// Otherwise check for a resource click (and we have a selected unit)
		// NOTE: Could probably just pass any other game object in here in future
		//else if(gameObject.GetComponent("ResourceDeposit") && selectedUnit != null)
		else if(selectedUnit != null)
		{
			// Check the type of click
			if(rightClick)
			{
				// Right-click, send the unit to the target location
				selectedUnit.SetNavTarget(gameObject);
			}
		}
	}
	
	public override void MouseMove(GameObject gameObject, Vector3 position)
	{
		
	}
	
	public override void MouseExit(GameObject gameObject, Vector3 position)
	{
		
	}
		
	// Deselect the current unit
	void Deselect()
	{
		// Get rid of the indicator
		GameObject.Destroy(indicator);

		selectedUnit = null;
	}
		
	// Set the navigation target
	void SetTarget(Vector3 location)
	{
		// Set the new target
		targetMarker.transform.position = location;
			
		// Initialise pathfinding order
		if(selectedUnit)
			selectedUnit.SetNavTarget(location);
		
		//if(selectedObject)
		//	selectedObject.SetNewTarget(location);
	}
}
