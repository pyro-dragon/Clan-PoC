using UnityEngine;
using System.Collections;

public class Interface
{
	public SelecterTool selecterTool;
	public BuilderTool builderTool;
	public PointerTool currentTool;
	
	public string testString;

	// Constructor
	public Interface () 
	{
		selecterTool = new SelecterTool();
		
		builderTool = new BuilderTool();
		
		currentTool = selecterTool;
	}
	
	// return a reference to the currently selected tool
	public PointerTool GetCurrentTool()
	{
		return currentTool;
	}
}
