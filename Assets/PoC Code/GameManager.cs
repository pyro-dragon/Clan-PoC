using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public Terrain terrain;
	public GameObject target;
	public Unit selectedUnit;
	public GameObject selectIndicator;
	public GameObject indicatePrefab;
	Interface userInterface;

	// Use this for initialization
	void Start () 
	{
		// Grab the user interface
		userInterface = new Interface();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Check for a change tool event
		if(Input.GetKeyUp(KeyCode.LeftControl))
		{
			// Switch the tool
			Debug.Log("Output of CompareTo: " + userInterface.currentToolName.CompareTo("select"));
			if(userInterface.currentToolName.CompareTo("select") == 0)
			{
				userInterface.ChangeTool("build");
			}
			else
			{
				userInterface.ChangeTool("select");
			}
		}
	}
	
	public void SetTarget(Vector3 location)
	{
		// Set the new target
		print("location: " + location.ToString());
		target.transform.position = location;
		
		// Initialise pathfinding order
		if(selectedUnit)
			selectedUnit.SetNavTarget(location);
	}
	
	public void SetSelected(Unit unit)
	{
        // Remove current selection
        Deselect();

		// Set the selected object
		selectedUnit = unit;
		
		// Create a new indicator
		selectIndicator = GameObject.Instantiate(indicatePrefab, selectedUnit.transform.position, Quaternion.identity) as GameObject;
		
		// Set the indicator as a member of the selected unit
		selectIndicator.transform.parent = selectedUnit.transform;
	}
	
	public void Deselect()
	{
		// Get rid of the indicator
		Destroy(selectIndicator);
		
		selectedUnit = null;
	}
	
	// Return a reference to the user interface
	public Interface GetUserInterface()
	{
		return userInterface;
	}
}
