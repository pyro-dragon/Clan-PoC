using UnityEngine;
using System.Collections;

public class CursorInteractor : MonoBehaviour 
{
	public Camera activeCamera;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Get look ray
		Ray ray = activeCamera.ScreenPointToRay(Input.mousePosition);
		
		// Debug- draw the ray
		Debug.DrawRay(ray.origin, ray.direction, Color.yellow);
		
		if(Input.GetMouseButtonUp(0))
			Debug.Log("Ray direction: " + ray.direction);
	}
}
