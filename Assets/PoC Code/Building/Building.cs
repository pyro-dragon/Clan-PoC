using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour
{
	/*public enum Mode
	{
		VALID_FOOTPRINT,
		INVALID_FOOTPRINT,
		NORMAL,
	}*/

	//public Mode mode;
	//private Color validFootprintColour = Color.green;
	//private Color inValidFootprintColour = Color.red;
	//private MeshFilter meshFilter;
	//private Shader defaultShader;
	//private Color defaultColor;

	/*void Awake()
	{
		meshFilter = GetComponentInChildren<MeshFilter>();
		defaultShader = meshFilter.renderer.material.shader;
		defaultColor = meshFilter.renderer.material.color;
	}

	public void SetNormal()
	{
		mode = Mode.NORMAL;
		meshFilter.renderer.material.shader = defaultShader;
		meshFilter.renderer.material.color = defaultColor;

	}

	public void SetValidFootPrint()
	{
		mode = Mode.VALID_FOOTPRINT;
		meshFilter.renderer.material.shader = Shader.Find("Custom/Footprint");
		meshFilter.renderer.material.color = validFootprintColour;

	}

	public void SetInValidFootPrint()
	{
		mode = Mode.INVALID_FOOTPRINT;
		meshFilter.renderer.material.shader = Shader.Find("Custom/Footprint");
		meshFilter.renderer.material.color = inValidFootprintColour;
	}

	public bool CheckSite()
	{

		if (meshFilter == null)
			return false;
		var mesh = meshFilter.mesh;
		if (mesh == null)
			return false;

		var t = meshFilter.transform;
		var min = mesh.bounds.min;
		var max = mesh.bounds.max;

		var corners = new Vector3[]
		{
			t.TransformPoint(new Vector3(min.x, min.y, min.z)),
			t.TransformPoint(new Vector3(min.x, min.y, max.z)),
			t.TransformPoint(new Vector3(max.x, min.y, min.z)),
			t.TransformPoint(new Vector3(max.x, min.y, max.z)),
			t.TransformPoint(new Vector3(0, min.y, 0)),
		};

		int groundLayer = 1 << LayerMask.NameToLayer("Ground");
		for (int i = 0; i < corners.Length; i++)
		{
			RaycastHit h;
			var startPos = corners[i] + Vector3.up * 10f;
			if (Physics.Raycast(new Ray(startPos, Vector3.down), out h, 1000f, groundLayer))
			{
				Debug.DrawLine(startPos, h.point);
				corners[i] = h.point;
			}
		}

		const float MAX_INCLINE = 0.1f;
		for (int i = 0; i < corners.Length; i++)
		{
			for (int j = 0; j < corners.Length; j++)
			{
				if (i == j)
					continue;
				float incline = Mathf.Abs((corners[i] - corners[j]).normalized.y);
				Debug.Log("incline " + incline);
				if ( incline > MAX_INCLINE)
					return false;
			}
		}

		return true;
	}*/
}
