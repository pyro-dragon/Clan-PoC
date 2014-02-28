using UnityEngine;
using System.Collections;

public class UserInterface : MonoBehaviour 
{
	public SelecterTool selecterTool;	// The selecter tool
	public BuilderTool builderTool;		// The builder tool
	public PointerTool currentTool;		// The pointer tool
	public string currentToolName;		// The name of the current tool- according to the hash table
	public Hashtable toolList;			// The list of tools available
	public Camera activeCamera;			// The current, active camera. Used to determine screen to world raycasting
	public float viewDistance;			// The distance between the near and far viewplanes- used for raycasting
	
	// Use this for initialization
	void Start () 
	{
		toolList = new Hashtable();
		toolList.Add("select", new SelecterTool());
		toolList.Add("build", new BuilderTool());
		currentToolName = "select";
		selecterTool = new SelecterTool();
		builderTool = new BuilderTool();		
		currentTool = selecterTool;
		viewDistance = activeCamera.farClipPlane - activeCamera.nearClipPlane;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Get look ray
		Ray ray = activeCamera.ScreenPointToRay(Input.mousePosition);
		
		// Get all hit objects
		RaycastHit[] hits = Physics.RaycastAll(ray, viewDistance);
		RaycastHit ter = new RaycastHit(); 
		Physics.Raycast(ray, out ter, viewDistance, 1 << LayerMask.NameToLayer("Ground"));
		
		// Debug- draw the ray
		Debug.DrawRay(ray.origin, ray.direction * 400, Color.yellow, 0, true);
		
		/*if(Input.GetMouseButtonUp(0))
		{
			//Debug.Log("object count: " + hits.Length);
			foreach(RaycastHit hit in hits)
			{
				Debug.Log("Object: " + hit.collider.name);
			}
			Debug.Log("Terrain: " + ter.point);
		}*/
		
		currentTool.Update(hits, ter.point);
	}
	
	// return a reference to the currently selected tool
	public PointerTool GetCurrentTool()
	{
		return toolList[currentToolName] as PointerTool;
		//return currentTool;
	}
	
	public bool ChangeTool(string toolName)
	{
		// Check if the tool exists
		if(toolList.ContainsKey(toolName))
		{
			Debug.Log("Tool exists, switching to tool " + toolName);
			currentTool.SwitchAway();
			currentToolName = toolName;
			currentTool.SwitchTo();
			return true;
		}
		else
		{
			Debug.Log(toolName + " does not exist");
			return false;
		}
	}
}
