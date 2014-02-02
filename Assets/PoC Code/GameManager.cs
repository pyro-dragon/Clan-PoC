using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public Terrain terrain;
	public GameObject target;
	public Unit selectedUnit;
	public GameObject selectIndicator;
	public GameObject indicatePrefab;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Check for a change tool event
		
		// Switch the tool
		
		
	}
	
	public void SetTarget(Vector3 location)
	{
		// Set the new target
		print("location: " + location.ToString());
		target.transform.position = location;
		
		// Initialise pathfinding order
		if(selectedUnit)
			selectedUnit.SetNewTarget(location);
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
}
