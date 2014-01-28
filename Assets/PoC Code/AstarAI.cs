using UnityEngine;
using System.Collections;
//Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
//This line should always be present at the top of scripts which use %Pathfinding
using Pathfinding;
public class AstarAI : MonoBehaviour 
{
	public Vector3 targetPosition;	// The point to move to
	
	private Seeker seeker;
	private CharacterController controller;
	
	public Path path;	// The calculated path
	
	public float speed = 100;	// The AI's speed per second
	
	public float nextWaypointDistance = 3;	// The max distance from the AI to a waypoint for it to continue to the next waypoint
	
	private int currentWaypoint = 0;	// The waypoint we are currently moving towards
	
	public void Start () 
	{
		//Get a reference to the Seeker component we added earlier
		Seeker seeker = GetComponent<Seeker>();
		
		// Get reference to the CharacterController component we added earlier
		controller = GetComponent<CharacterController>();
		
		// Start a new path to the targetPosition, return the the OnPathComplete function
		seeker.StartPath(transform.position, targetPosition, OnPathComplete);
		
		// OnPathComplete will be called every time a path is returned to this seeked
		//seeker.pathCallback += OnPathComplete;
		
		//Start a new path to the targetPosition
		//seeker.StartPath (transform.position,targetPosition);
	}
	
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
}
