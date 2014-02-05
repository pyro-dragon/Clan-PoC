using UnityEngine;
using System.Collections;

//Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
//This line should always be present at the top of scripts which use %Pathfinding
using Pathfinding;

public class Unit : MonoBehaviour 
{
	public GameManager gameManager;	// The game manager object
	
	public Vector3 targetPosition;	// The point to move to
	private CharacterController controller;
	public Path path;	// The calculated path
	public float speed = 100;	// The AI's speed per second
	public float nextWaypointDistance = 3;	// The max distance from the AI to a waypoint for it to continue to the next waypoint
	private int currentWaypoint = 0;	// The waypoint we are currently moving towards
	private Seeker seeker;	// The path seeker
	
	public void Start () 
	{
		// Get a link to the game manager
		gameManager = (GameManager)GameObject.Find("GameManager").GetComponent("GameManager");
		
		//Get a reference to the Seeker component we added earlier
		seeker = GetComponent<Seeker>();
		
		// Get reference to the CharacterController component we added earlier
		controller = GetComponent<CharacterController>();
	}
	
	// When the mouse is clicked over the unit
	public void OnClick()
	{
		print("Unit clicked!");
		
		//gameManager.SetSelected(this);
		gameManager.GetUserInterface().GetCurrentTool().UnitClicked(this, false);
		//gameManager.GetUserInterface().GetCurrentTool().Click(this, this.transform.position, false);
	}
	
	// When the mouse is clicked over the unit
	public void OnMouseUp()
	{
		print("Unit clicked! {UP}");
		
		//gameManager.SetSelected(this);
		gameManager.GetUserInterface().GetCurrentTool().UnitClicked(this, false);
	}
	
	// The function to perform when a valid path is found
	public void OnPathComplete (Path p) 
	{
		Debug.Log ("Yey, we got a path back. Did it have an error? "+p.error);
		if(!p.error)
		{
			path = p;
			
			// Reset the waypoint counter
			currentWaypoint = 0;
		}
	}
	
	// Update the unit moving on the path
	public void FixedUpdate()
	{
		if(path == null)
		{
			// We have no path to move after yet
			return;
		}
		
		if(currentWaypoint >= path.vectorPath.Count)
		{
			//Debug.Log("End of path reached");
			return;
		}
		
		//Debug.Log("Next step");
		
		// Direction to the next waypoint
		 Vector3 dir = (path.vectorPath[currentWaypoint]-transform.position).normalized;
		dir *= speed * Time.fixedDeltaTime;
		controller.SimpleMove (dir);
		
		// Check if we are close enough to the next waypoint
		// If we are, proceed to follow the next waypoint
		if(Vector3.Distance (transform.position,path.vectorPath[currentWaypoint]) < nextWaypointDistance)
		{
			currentWaypoint++;
			return;
		}
	}
	
	// When the object is removed
	public void OnDisable()
	{
		// Remove callback function
		//seeker.pathCallback -= OnPathComplete;
	}
	
	// Set a new target location
	public void SetNewTarget(Vector3 target)
	{
		// Set the target position
		targetPosition = target;
		
		// Create a new path
		seeker.StartPath(transform.position, targetPosition, OnPathComplete);
	}
}
