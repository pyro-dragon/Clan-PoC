using UnityEngine;
using System.Collections;

//-----------------------------------------------------------------------------
// A script used to fuck about with the terrain to prepare it for the game
//-----------------------------------------------------------------------------
public class TerrainInitaliser : MonoBehaviour 
{
	// Put as many of the variables into the start function as possible after- they are only needed at the start. 
	public TreeInstance[] trees;
	public ArrayList treeArray;
	
	// Use this for initialization
	void Start () 
	{
		// Grab the tree array from the terrain
		trees = Terrain.activeTerrain.terrainData.treeInstances;
		//treeArray.AddRange(Terrain.activeTerrain.terrainData.treeInstances);
		
		// Substitute all the trees for game objects
		foreach(TreeInstance tree in trees)
		{
			GameObject newTree = null;
			
			switch(tree.prototypeIndex)
			{
				case 0 : 
				{
					newTree = GameObject.Instantiate(Resources.Load("PoC Prefabs/OakTree")) as GameObject;
				}; break; 
				
				case 1 : 
				{
					newTree = GameObject.Instantiate(Resources.Load("PoC Prefabs/PalmTree")) as GameObject;
				}; break; 
				
				default : 
				{
					return;
				}
			}
			
			// Set the properties
			newTree.transform.position = tree.position;
		}
		
		//TreeInstance[] nulltrees;
		//treeArray.Clear();
		trees.Initialize();
		
		// Remove the built-in trees from the terrain
		Terrain.activeTerrain.terrainData.treeInstances.Initialize();// = trees;
		
		// Refresh the terrain
		float[,] heights = Terrain.activeTerrain.terrainData.GetHeights(0, 0, 0, 0);
		Terrain.activeTerrain.terrainData.SetHeights(0, 0, heights);
		
		Debug.Log("Done");
	}
}
