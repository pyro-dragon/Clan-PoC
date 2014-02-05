﻿using UnityEngine;
using System.Collections;

// The unit selection and command tool
public class SelecterTool : PointerTool
{
	Unit selectedUnit;		// Selected unit
	GameObject selectedObject; 
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
		
	// A general click function
	public override void Click(GameObject gameObject, Vector3 position, bool rightClick)
	{
		if(gameObject.GetType().ToString() == "Unit")
		{
			// Check the type of the click
			if(!rightClick)
			{
				// Remove current selection
				Deselect();
		
				// Set the selected object
				selectedObject = gameObject;
		
				// Create a new indicator
				indicator = GameObject.Instantiate(Resources.Load("IndicatorPrefab")) as GameObject;
		
				// Set the indicator as a member of the selected unit
				indicator.transform.position = selectedObject.transform.position;
				indicator.transform.parent = selectedObject.transform;
			}
		}
	}
	
	public override void MouseOver(GameObject gameObject, Vector3 position)
	{
		
	}
	
	public override void MouseExit(GameObject gameObject, Vector3 position)
	{
		
	}
		
	// A unit has been clicked
	public override void UnitClicked(Unit unit, bool rightClick)
	{
		Debug.Log("Clicked item: " + unit.GetType());
		
		GameObject obj = (GameObject)unit; 
		
		Debug.Log("Clicked item: " + obj.GetType());
		
		
		// Check the type of the click
		if(!rightClick)
		{
			// Remove current selection
			Deselect();
	
			// Set the selected object
			selectedUnit = unit;
	
			// Create a new indicator
			indicator = GameObject.Instantiate(Resources.Load("IndicatorPrefab")) as GameObject;
	
			// Set the indicator as a member of the selected unit
			indicator.transform.position = selectedUnit.transform.position;
			indicator.transform.parent = selectedUnit.transform;
		}
	}
		
	// The terrain has been clicked
	public override void TerrainClicked(Vector3 position, bool righClick)
	{
		
		// Check the type of click
		if(righClick)
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
			selectedUnit.SetNewTarget(location);
	}
}
