using UnityEngine;
using System.Collections;

public abstract class PointerTool
{
	public string name;
	
	public abstract void Click(GameObject gameObject, Vector3 position, bool rightClick);

	public abstract void UnitClicked(Unit unit, bool rightClick);

	public abstract void TerrainClicked(Vector3 position, bool rightClick);
}
