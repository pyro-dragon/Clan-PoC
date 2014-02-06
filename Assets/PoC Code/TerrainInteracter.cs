using UnityEngine;
using System.Collections;

public class TerrainInteracter : MonoBehaviour 
{
	public GameManager manager;
	
	public Ray ray;
	public RaycastHit hit;
	public Vector3 hitPoint;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	public void OnMouseOver()
	{
		// Check for are right-click
		if(Input.GetMouseButtonUp(1))
		{
			// Transmit the location
			manager.GetUserInterface().GetCurrentTool().Click(this.gameObject, GetIntersectionPoint(), true);
		}
	}
	
	public void OnMouseUp()
	{
		// Left-click on the terrain- deselect whatever is selected
		manager.GetUserInterface().GetCurrentTool().Click(this.gameObject, GetIntersectionPoint(), false);
	}
	
	public Vector3 GetIntersectionPoint()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	    Physics.Raycast(ray, out hit, Mathf.Infinity);
		return hit.point;
	}
}
