using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public Terrain terrain;
	public GameObject target;
	public Unit selectedUnit;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
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
		selectedUnit = unit;
	}
}
