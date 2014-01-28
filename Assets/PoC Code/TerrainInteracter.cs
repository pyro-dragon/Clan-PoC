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
	
	public void OnMouseUp()
	{
		// Find the interception point
		//ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        //Physics.Raycast(ray, out hit, 10000.0f, 8);   // ray is 100 units long. We are just looking at the ground layer (8)
        //;
		
		print("Terrain clicked!");
		
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, Mathf.Infinity);
		hitPoint = hit.point;
		
		// Transmit the location
		manager.SetTarget(hitPoint);
	}
}
