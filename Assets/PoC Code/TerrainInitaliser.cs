using UnityEngine;
using System.Collections;

//-----------------------------------------------------------------------------
// A script used to fuck about with the terrain to prepare it for the game
//-----------------------------------------------------------------------------
public class TerrainInitaliser : MonoBehaviour 
{
	// Put as many of the variables into the start function as possible after- they are only needed at the start. 
	public ArrayList treeArray;
	
	// Use this for initialization
	void Start () 
	{
		// Grab the tree array from the terrain
		treeArray = new ArrayList(Terrain.activeTerrain.terrainData.treeInstances);
		int originalCount = treeArray.Count -1;
		//Debug.Log("Tree instances: " + originalCount);
		
		// Substitute all the trees for game objects
		for(int i = 0; i <= originalCount; i++)
		{
			GameObject newTree = null;
			
			switch(((TreeInstance)treeArray[0]).prototypeIndex)
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
			newTree.transform.position = new Vector3(
				Terrain.activeTerrain.terrainData.size.x * ((TreeInstance)treeArray[0]).position.x, 
				Terrain.activeTerrain.terrainData.size.y * ((TreeInstance)treeArray[0]).position.y, 
				Terrain.activeTerrain.terrainData.size.z * ((TreeInstance)treeArray[0]).position.z
			);
			
			newTree.transform.localScale = new Vector3(
				((TreeInstance)treeArray[0]).widthScale, 
				((TreeInstance)treeArray[0]).heightScale, 
				((TreeInstance)treeArray[0]).widthScale
			);
			
			// Remove this tree
			treeArray.RemoveAt(0);
		}
		
		// Remove the built-in trees from the terrain
		TreeInstance[] tmpArray = new TreeInstance[0];
		treeArray.CopyTo(tmpArray);
		Terrain.activeTerrain.terrainData.treeInstances = tmpArray;
		
		// Refresh the terrain
		float[,] heights = Terrain.activeTerrain.terrainData.GetHeights(0, 0, 0, 0);
		Terrain.activeTerrain.terrainData.SetHeights(0, 0, heights);
		
		//Debug.Log("Done");
	}
}
