using UnityEngine;
using System.Collections;

public class UserInterface : MonoBehaviour 
{
	public SelecterTool selecterTool;	// The selecter tool
	public BuilderTool builderTool;		// The builder tool
	public PointerTool currentTool;		// The currently selected tool
	public string currentToolName;		// The name of the current tool- according to the hash table
	public Hashtable toolList;			// The list of tools available
	public Camera activeCamera;			// The current, active camera. Used to determine screen to world raycasting
	public float viewDistance;			// The distance between the near and far viewplanes- used for raycasting
	
	public RaycastHit terrainHit;		// The terrain hit location
	public RaycastHit target;			// Any other hit target
	public bool hitStatus;				// If we actully hit anything
	
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
		
		// Get the ground hit point
		Physics.Raycast(ray, out terrainHit, viewDistance, 1 << LayerMask.NameToLayer("Ground"));
		
		// Get the first object hit
		hitStatus = Physics.Raycast(ray, out target, viewDistance, ~(1 << LayerMask.NameToLayer("Ground")));
		
		// Send the data to the current tool
		currentTool.Update(target, terrainHit.point, hitStatus);
		
		
		// Debug- draw the ray
		Debug.DrawRay(ray.origin, ray.direction * viewDistance, Color.yellow, 0, true);
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
			//currentTool.SwitchAway();
			currentToolName = toolName;
			//currentTool.SwitchTo();
			return true;
		}
		else
		{
			Debug.Log(toolName + " does not exist");
			return false;
		}
	}
}
