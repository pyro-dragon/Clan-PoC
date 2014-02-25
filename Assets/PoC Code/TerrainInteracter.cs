using UnityEngine;
using System.Collections;

public class TerrainInteracter : MonoBehaviour 
{
	public GameManager manager;
	
	public Ray ray;
	public RaycastHit hit;
	public Vector3 hitPoint;
	public bool passthrough;	// Controls if we are getting terrain interaction anyways
	
	// Use this for initialization
	void Start () 
	{
		passthrough = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(passthrough)
		{
			// Check for left click
			if(Input.GetMouseButtonUp(0))
			{
				// Transmit the location
				manager.GetUserInterface().GetCurrentTool().Click(this.gameObject, GetIntersectionPoint(), false);
			}
			// Check for right click
			else if(Input.GetMouseButtonUp(1))
			{
				// Transmit the location
				manager.GetUserInterface().GetCurrentTool().Click(this.gameObject, GetIntersectionPoint(), true);
			}
			// No buttons down
			else
			{
				// Just send the mouse position
				manager.GetUserInterface().GetCurrentTool().MouseMove(this.gameObject, GetIntersectionPoint());
			}
		}
	}
	
	public void OnMouseOver()
	{
		if(!passthrough)
		{
			// Check for are right-click
			if(Input.GetMouseButtonUp(1))
			{
				// Transmit the location
				manager.GetUserInterface().GetCurrentTool().Click(this.gameObject, GetIntersectionPoint(), true);
			}
			else
			{
				// Just send the mouse position
				manager.GetUserInterface().GetCurrentTool().MouseMove(this.gameObject, GetIntersectionPoint());
			}
		}
	}
	
	public void OnMouseUp()
	{
		if(!passthrough)
		{
			// Left-click on the terrain- deselect whatever is selected
			manager.GetUserInterface().GetCurrentTool().Click(this.gameObject, GetIntersectionPoint(), false);
		}
	}
	
	// Set the passthrough option
	void SetPassthrough(bool passthrough)
	{
		this.passthrough = passthrough;
	}
	
	// Return the passthrough status
	bool GetPassthrough()
	{
		return passthrough;
	}
	
	// Return the point that the mouse intersects with the terrain
	public Vector3 GetIntersectionPoint()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	    Physics.Raycast(ray, out hit, Mathf.Infinity);
		return hit.point;
	}
}
