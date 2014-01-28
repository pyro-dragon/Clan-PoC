using UnityEngine;
using System.Collections;

public class Interacter : MonoBehaviour {

	public bool mouseOver;
	public bool clicked;
	
	// Use this for initialization
	void Start () {
		mouseOver = false;
		clicked = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseOver()
	{
		mouseOver = true;
	}
	
	void OnMouseExit()
	{
		mouseOver = false;
	}
	
	void OnMouseDown()
	{
		clicked = true;
	}
}
