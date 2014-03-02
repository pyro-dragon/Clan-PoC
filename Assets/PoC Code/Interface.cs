using UnityEngine;
using System.Collections;

public class Interface
{
	public SelecterTool selecterTool;
	public BuilderTool builderTool;
	public PointerTool currentTool;
	
	public string currentToolName;
	public Hashtable toolList;

	// Constructor
	public Interface () 
	{
		toolList = new Hashtable();
		toolList.Add("select", new SelecterTool());
		toolList.Add("build", new BuilderTool());
		currentToolName = "select";
		
		selecterTool = new SelecterTool();
		
		builderTool = new BuilderTool();
		
		currentTool = selecterTool;
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
