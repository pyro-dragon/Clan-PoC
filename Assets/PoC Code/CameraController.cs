using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	int moveSpeed;
	int zoomSpeed;
	int rotateSpeed;
	int minZoom;
	int maxZoom;

	// Use this for initialization
	void Start () 
	{
		moveSpeed = 5;
		zoomSpeed = 15;
		rotateSpeed = 20;
		minZoom = 20; 
		maxZoom = 100;

		Vector3 direction = Vector3.forward;
		Debug.Log("Direction: " + direction);
		direction.y = 0.0f;
		Debug.Log("Direction: " + direction);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.W))
			transform.Translate(Vector3.back * (moveSpeed * Time.deltaTime), Space.World);

		if(Input.GetKey(KeyCode.S))
			transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime), Space.World);

		if(Input.GetKey(KeyCode.A))
			transform.Translate(Vector3.left * (moveSpeed * Time.deltaTime));

		if(Input.GetKey(KeyCode.D))
			transform.Translate(Vector3.right * (moveSpeed * Time.deltaTime));

		if(Input.GetKey(KeyCode.Q))
			transform.Rotate(Vector3.down * (rotateSpeed * Time.deltaTime), Space.World);

		if(Input.GetKey(KeyCode.E))
			transform.Rotate(Vector3.up * (rotateSpeed * Time.deltaTime), Space.World);

		if(Input.GetKey(KeyCode.KeypadPlus))
		{
			transform.Translate(Vector3.up * (zoomSpeed * Time.deltaTime));
			transform.Rotate(Vector3.left * (rotateSpeed/4 * Time.deltaTime), Space.World);
		}
		
		if(Input.GetKey(KeyCode.KeypadMinus))
		{
			transform.Translate(Vector3.down * (zoomSpeed * Time.deltaTime));
			transform.Rotate(Vector3.right * (rotateSpeed/4 * Time.deltaTime), Space.World);
		}
	}
}
