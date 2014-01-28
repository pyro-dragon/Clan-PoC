using UnityEngine;
using System.Collections;

public class cursor : MonoBehaviour 
{
    public Vector2 terrainPoint;       // Pont on terrain that the cursor is hitting
    public GameObject selectedObject;  // The currently selected object
    public Camera camera;              // The main viewing camera
    public Terrain terrain;            // The terrain

	// Use this for initialization
	void Start () 
    {
        // Reset the position of the cursor
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () 
    {
        // Get the new position of the cursor
        //transform.position = new Vector3();

        // Check where cursor impacts terrain
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 100.0f, 8);   // ray is 100 units long. We are just looking at the ground layer (8)
        terrainPoint = hit.point;
	}
}
