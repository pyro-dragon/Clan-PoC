using UnityEngine;
using System.Collections;

public class CursorInteractor : MonoBehaviour 
{
	public Camera activeCamera;
	public Interface ui;
	
	// Use this for initialization
	void Start () 
	{
		// Get the user interface
		//ui = ((GameManager)GameObject.Find("GameManager").GetComponent("GameManager")).userInterface;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Get look ray
		Ray ray = activeCamera.ScreenPointToRay(Input.mousePosition);
		
		// Get all hit objects
		RaycastHit[] hits = Physics.RaycastAll(ray, activeCamera.farClipPlane - activeCamera.nearClipPlane);
		RaycastHit ter = new RaycastHit(); 
		Physics.Raycast(ray, out ter, activeCamera.farClipPlane - activeCamera.nearClipPlane, 1 << LayerMask.NameToLayer("Ground"));
		
		// Debug- draw the ray
		Debug.DrawRay(ray.origin, ray.direction * 400, Color.yellow, 0, true);
		
		if(Input.GetMouseButtonUp(0))
		{
			//Debug.Log("object count: " + hits.Length);
			foreach(RaycastHit hit in hits)
			{
				Debug.Log("Object: " + hit.collider.name);
			}
			Debug.Log("Terrain: " + ter.point);
		}
	}
}
