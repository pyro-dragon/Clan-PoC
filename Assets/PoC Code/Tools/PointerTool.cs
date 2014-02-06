﻿using UnityEngine;
using System.Collections;

public abstract class PointerTool
{
	public string name;
	
	public abstract void Click(GameObject gameObject, Vector3 position, bool rightClick);
	
	public abstract void MouseOver(GameObject gameObject, Vector3 position);
	
	public abstract void MouseExit(GameObject gameObject, Vector3 position);
}
